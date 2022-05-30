using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accesa.SportsBuddy.Controllers
{
    [Authorize]
    [ApiController]
    [Route("review")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetReviewsByTrainingId(int id)
        {
            try
            {
                var reviews = _reviewService.GetReviewsByTrainingId(id);
                if (reviews is null)
                {
                    throw new Exception("No reviews found!");
                }

                var reviewsDTO = _mapper.Map<IList<ReviewDTO>>(reviews.ToList());
                if (reviewsDTO is null)
                {
                    throw new Exception("Unable to fetch all reviews!");
                }

                return Ok(reviewsDTO);
            }
            catch (Exception ex)
            {
                return NotFound($"Internal error: {ex.Message}");
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddReview([FromBody] ReviewDTO review)
        {
            try
            {
                _reviewService.AddReviewForUser(new Review
                {
                    Rating = review.Rating,
                    Comment = review.Comment,
                    TraineeId = review.TraineeId,
                    TrainingId = review.TrainingId,
                    CreatedAt = review.CreatedAt
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal error: {ex.Message}");
            }
        }
    }
}
