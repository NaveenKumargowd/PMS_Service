using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMS_UserAPI.DTO;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageController(ILogger<MessageController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [Route("GetAllSentNotes/{senderId}")]
        [HttpGet]
        public async Task<IActionResult> GetSentNotes(int senderId)
        {
            try
            {
                var notes = await _unitOfWork.Notes.GetAll(n => n.SenderEmployeeID == senderId);
                var result =  _mapper.Map<IList<NotesDTO>>(notes);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return Problem("Error Occured",statusCode:500);
            }
            
        }
        [Route("GetAllReceivedNotes/{receiverID}")]
        [HttpGet]
        public async Task<IActionResult> GetReceivedNotes(int receiverID)
        {
            try
            {
                var notes = await _unitOfWork.Notes.GetAll(n => n.RecipientEmployeeID == receiverID);
                var result = _mapper.Map<IList<NotesDTO>>(notes);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return Problem("Error Occured", statusCode: 500);
            }

        }

        [HttpPost]
        [Route("InsertNote")]
        public async Task<IActionResult> AddNote([FromBody] CreateNotesDTO createNotesDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post Attempt in {nameof(AddNote)}");
                return BadRequest(ModelState);
            }
            try
            {
                var result = _mapper.Map<Notes>(createNotesDTO);
                await _unitOfWork.Notes.Insert(result);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetAllNotes", new { id = result.NoteId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception Message {ex.Message}");
                return StatusCode(500, "Internal Server error");
            }
        }
    }
}
