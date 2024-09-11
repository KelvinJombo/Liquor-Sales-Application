using CartTransactionService.Messages;
using CartTransactionService.Models.Dtos;
using CartTransactionService.Repository;
using CartTransactionServices.Models.Dtos;
using LiquorSale.MessageBus;
using Microsoft.AspNetCore.Mvc;

namespace CartTransactionServices.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        protected ResponseDto _response;
        private readonly IMessageBus _messageBus;
        private readonly ICouponRepository _couponRepository;

        public CartController(ICartRepository cartRepository, IMessageBus messageBus, ICouponRepository couponRepository)
        {
            _cartRepository = cartRepository;
            _response = new ResponseDto();
            _messageBus = messageBus;
            _couponRepository = couponRepository;
        }


        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(userId);
                _response.Result = cartDto;         
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>(){ex.ToString()};
                
            }
            return _response;
        }



        [HttpPost("AddToCart")]
        public async Task<object> AddToCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDtO = await _cartRepository.CreateUpdateCart(cartDto);
                _response.Result = cartDtO;         
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>(){ex.ToString()};
                
            }
            return _response;
        }



         [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDtO = await _cartRepository.CreateUpdateCart(cartDto);
                _response.Result = cartDtO;         
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>(){ex.ToString()};
                
            }
            return _response;
        }



         [HttpPost("RemoveFromCart")]
        public async Task<object> RemoveCart([FromBody]string cartId)
        {
            try
            {
                bool IsSuccess = await _cartRepository.RemoveFromCart(cartId);
                _response.Result = IsSuccess;         
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>(){ex.ToString()};
                
            }
            return _response;
        }


         [HttpGet("ClearCart")]
        public async Task<object> ClearCart(string userId)
        {
            try
            {
                bool IsSuccess = await _cartRepository.ClearCart(userId);
                _response.Result = IsSuccess;         
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>(){ex.ToString()};
                
            }
            return _response;
        }



        [HttpPost("Checkout")]
        public async Task<object> Checkout(CheckoutHeaderDto checkout)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkout.UserId);
                if(cartDto == null)
                {
                    return BadRequest();
                }

                if(!string.IsNullOrEmpty(checkout.CouponCode))
                {
                    CouponDto couponDto = await _couponRepository.GetCoupon(checkout.CouponCode);
                    if(checkout.DiscountTotal != couponDto.DiscountAmount)
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>(){"Coupon Price has changed, please confirn and try again"};
                        _response.DisplayMessage = "Coupon Price Has Changed, please Confirm and try again.";
                        return _response;
                    }
                }

                checkout.CartDetails = cartDto.CartDetails.Select(cd => new CartDetailsDto
                {
                    CartDetailsId = cd.CartDetailsId,
                    CartHeaderId = cd.CartHeaderId,
                    ProductsId = cd.ProductsId,
                    Products = cd.Products,
                    TotalAmount = cd.TotalAmount, 
                    Count = cd.Count
                }).ToList();

                //logic to add message to process order
                await _messageBus.PublishMessage(checkout, "checkoutmessagetopic");

            }
            catch(Exception ex)
            {
                _response.IsSuccess=false;
                _response.ErrorMessages = new List<string>(){ex.ToString() };
            }
            return _response;
        }


    }
}