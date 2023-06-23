using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using API.Dtos;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public UsersController(IUserRepository userRepository, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            /*var users = await _userRepository.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<AppUser>, IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn);*/

            return Ok(await _userRepository.GetMembersAsync());
        }
        
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<MemberDto>> GetUserById(int id)
        {
            /*var user = await _userRepository.GetUserByIdAsync(id);
            var userToReturn = _mapper.Map<AppUser, MemberDto>(user);
            return userToReturn;*/

            return Ok(await _userRepository.GetMemberAsync(id));
        }

        [HttpGet("GetUserByUsername/{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
        {
            /*var user = await _userRepository.GetUserByUsernameAsync(username);
            var userToReturn = _mapper.Map<AppUser, MemberDto>(user);
            return userToReturn;*/

            return Ok(await _userRepository.GetMemberAsync(username));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            
            if (user == null) return NotFound();

            _mapper.Map(memberUpdateDto, user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<photoDto>> AddPhoto(IFormFile file)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            
            if (user == null) return NotFound();

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null ) return BadRequest(result.Error.Message);

            var photo = new photo
            {
                Url = result.SecureUri.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (user.Photos.Count == 0) photo.IsMain = true;

            user.Photos.Add(photo);

            if (await _userRepository.SaveAllAsync()) 
            {
                return CreatedAtAction  (nameof(GetUserByUsername), new {username = user.UserName}, 
                    _mapper.Map<photoDto>(photo)); 
            }

            return BadRequest("Problem while adding photo");
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            if (user == null) return NotFound();

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null) return NotFound();

            if (photo.IsMain) return BadRequest("This is already your main photo");

            var currentMain = user.Photos.FirstOrDefault(x=>x.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photo.IsMain = true;

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Problem setting main photo");
        }

    }
}