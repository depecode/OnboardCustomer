using Microsoft.AspNetCore.Mvc;
using OnboardCustomer.Data;
using OnboardCustomer.Models.Domain;
using OnboardCustomer.Models.DTO;
using OnboardCustomer.Repositories;

namespace OnboardCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardCustomerController : ControllerBase
    {
        private readonly OnboardCustomerDbContext _dbContext;
        private readonly IOnboardCustomerRepository _onboardCustomerRepository;
        public OnboardCustomerController(OnboardCustomerDbContext dbContext, IOnboardCustomerRepository onboardCustomerRepository) 
        {
            _dbContext = dbContext;
            _onboardCustomerRepository = onboardCustomerRepository;
        }

        //Post to Onboard New User
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
        {
            if (ModelState.IsValid)
            {
                var userModel = new User
                {
                    PhoneNumber = addUserRequestDto.PhoneNumber,
                    Password = addUserRequestDto.Password,
                    Email = addUserRequestDto.Email,
                    StateofResidence = addUserRequestDto.StateofResidence,
                    LGA = addUserRequestDto.LGA,

                };

                userModel = await _onboardCustomerRepository.CreateAsync(userModel);

                var userDto = new UserDto
                {
                    Id = userModel.Id,
                    PhoneNumber = userModel.PhoneNumber,
                    Password = userModel.Password,
                    Email = userModel.Email,
                    StateofResidence = userModel.StateofResidence,
                    LGA = userModel.LGA
                };

                return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //GET all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usersModel = await _onboardCustomerRepository.GetAllAsync();

            var userDto = new List<UserDto>();

            if (ModelState.IsValid)
            {


                foreach (var user in usersModel)
                {
                    userDto.Add(new UserDto()
                    {

                    });
                }

            }
            return Ok(userDto);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userModel = await _onboardCustomerRepository.GetByIdAsync(id);

            if(userModel == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = userModel.Id,
                PhoneNumber = userModel.PhoneNumber,
                Password = userModel.Password,
                Email = userModel.Email,
                StateofResidence = userModel.StateofResidence,
                LGA = userModel.LGA
            };

            return Ok(userDto);
        }
    }
}
