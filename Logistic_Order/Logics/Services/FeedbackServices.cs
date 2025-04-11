using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class FeedbackServices:IFeedbackServices
    {
        private readonly LoginDbContext _context;
        public FeedbackServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddFeedback(FeedbackRequest feedbackRequest)
        {
            try
            {
                var result = await _context.Feedbacks.AnyAsync(f => f.Feedback_Id == feedbackRequest.Feedback_Id);
                if (result)
                {
                    return "Feedback already exists";
                }
                Feedback feedback = new Feedback()
                {
                    Id=feedbackRequest.Id,
                    Feedback_Id = feedbackRequest.Feedback_Id,
                    Feedback_Message = feedbackRequest.Feedback_Message,
                    Feedback_Rating = feedbackRequest.Feedback_Rating,
                    Buyer_Id = feedbackRequest.Buyer_Id
                };
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
                return "Feedback added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<Feedback_Response> UpdateFeedback(int Feedback_Id, FeedbackRequest feedbackRequest)
        {
            try
            {
                var feedback = await _context.Feedbacks.FindAsync(Feedback_Id);
                if (feedback==null)
                {
                    return null;
                }
                feedback.Feedback_Message = feedbackRequest.Feedback_Message;
                feedback.Feedback_Rating = feedbackRequest.Feedback_Rating;
                feedback.Buyer_Id = feedbackRequest.Buyer_Id;
                _context.Feedbacks.Update(feedback);
                await _context.SaveChangesAsync();
                feedbackRequest.Feedback_Id = feedback.Feedback_Id;
                feedbackRequest.Feedback_Message = feedback.Feedback_Message;
                feedbackRequest.Feedback_Rating = feedback.Feedback_Rating;
                feedbackRequest.Buyer_Id = feedback.Buyer_Id;
                Feedback_Response feedbackResponse = new Feedback_Response()
                {
                    Feedback_Id = feedbackRequest.Feedback_Id,
                    Feedback_Message = feedbackRequest.Feedback_Message,
                    Feedback_Rating = feedbackRequest.Feedback_Rating,
                    Buyer_Id = feedbackRequest.Buyer_Id
                };
                return feedbackResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> DeleteFeedback(int Feedback_Id)
        {
            try
            {
                var feedback = await _context.Feedbacks.FindAsync(Feedback_Id);
                if (feedback == null)
                {
                    return "Feedback cannot be deleted";
                }
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
                return "feedback Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Feedback_Response> GetFeedbackById(int Feedback_id)
        {
            try
            {
                var feedback = await _context.Feedbacks.FindAsync(Feedback_id);
                if (feedback == null)
                {
                    return null;
                }
                feedback.Feedback_Id = feedback.Feedback_Id;
                feedback.Id = feedback.Id;
                feedback.Feedback_Message = feedback.Feedback_Message;
                feedback.Feedback_Rating = feedback.Feedback_Rating;
                feedback.Buyer_Id = feedback.Buyer_Id;
                Feedback_Response feedbackResponse = new Feedback_Response()
                {
                    Feedback_Id = feedback.Feedback_Id,
                    Feedback_Message = feedback.Feedback_Message,
                    Feedback_Rating = feedback.Feedback_Rating,
                    Buyer_Id = feedback.Buyer_Id,
                    Id = feedback.Id

                };
                return feedbackResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Feedback_Response>> GetAllFeedback()
        {
            try
            {
                var feedbacks = await _context.Feedbacks.ToListAsync();
                feedbacks.ForEach(feedback => {
                    feedback.Feedback_Id = feedback.Feedback_Id;
                    feedback.Id = feedback.Id;
                    feedback.Feedback_Message = feedback.Feedback_Message;
                    feedback.Feedback_Rating = feedback.Feedback_Rating;
                    feedback.Buyer_Id = feedback.Buyer_Id;
                });
                List<Feedback_Response> feedbackResponses = new List<Feedback_Response>();
                foreach (var feedback in feedbacks)
                {
                    Feedback_Response feedbackResponse = new Feedback_Response()
                    {
                        Feedback_Id = feedback.Feedback_Id,
                        Feedback_Message = feedback.Feedback_Message,
                        Feedback_Rating = feedback.Feedback_Rating,
                        Buyer_Id = feedback.Buyer_Id,
                        Id = feedback.Id
                    };
                    feedbackResponses.Add(feedbackResponse);
                }
                return feedbackResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    }
