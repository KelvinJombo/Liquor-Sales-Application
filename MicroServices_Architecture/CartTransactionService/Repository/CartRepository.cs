using AutoMapper;
using CartTransactionService.Data;
using CartTransactionService.Models;
using CartTransactionService.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CartTransactionService.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _db;
        private readonly IMapper _mapper;

        public CartRepository(CartDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }




        public async Task<bool> ClearCart(string userId)
        {
             var cartHeaderFromDb = await _db.CartHeaders.FirstOrDefaultAsync(x => x.UserId == userId);
             if (cartHeaderFromDb != null)
             {
                _db.CartDetails.RemoveRange(_db.CartDetails.Where(u => u.CartHeaderId == cartHeaderFromDb.CartHeaderId));
                _db.CartHeaders.Remove(cartHeaderFromDb);
                await _db.SaveChangesAsync(); 
                return true;  
             }

             return false;
        }

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {
            Cart cart = _mapper.Map<Cart>(cartDto);
                //Check if the product exists in Database, else Create it
            var productInDb = await _db.Products.FirstOrDefaultAsync(u => u.ProductsId == cartDto.CartDetails.FirstOrDefault().ProductsId);    
            if (productInDb == null)
            {
                _db.Products.Add(cart.CartDetails.FirstOrDefault().Products);
                await _db.SaveChangesAsync();
            }


            //Check if header is null

            var cartHeaderFromDb = await _db.CartHeaders.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == cart.CartHeader.UserId);
            if (cartHeaderFromDb == null)
            {
                //Create header and Details
                _db.CartHeaders.Add(cart.CartHeader);
                await _db.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Products = null;
                _db.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _db.SaveChangesAsync();
            }
            else
            {
                //if header is not null, 
                //Check if details has the same product
                var cartDetailsFromDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    u => u.ProductsId == cart.CartDetails.FirstOrDefault().ProductsId &&
                    u.CartHeaderId == cartHeaderFromDb.CartHeaderId);
                
                if (cartDetailsFromDb == null)
                {
                    //Create Details
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Products = null;
                    _db.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _db.SaveChangesAsync();
                }
                else
                {
                    //Update the Count or Cart Details
                    cart.CartDetails.FirstOrDefault().Products = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetailsFromDb.Count;
                    _db.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _db.SaveChangesAsync();
                }
            }

                return _mapper.Map<CartDto>(cart);


        }


        public async Task<CartDto> GetCartByUserId(string userId)
        {
             Cart cart = new()
             {
                CartHeader = await _db.CartHeaders.FirstOrDefaultAsync(x => x.UserId == userId)
             };

             cart.CartDetails = _db.CartDetails.Where(u => u.CartHeaderId == cart.CartHeader.CartHeaderId).Include(u => u.Products);
                return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveFromCart(string cartDetailsId)
        {
            try
            {


             CartDetails cartDetails = await _db.CartDetails.FirstOrDefaultAsync(u => u.CartDetailsId == cartDetailsId);
             
             int totalCountOfCartItems = _db.CartDetails.Where(u => u.CartHeaderId == cartDetails.CartHeaderId).Count();

             _db.CartDetails.Remove(cartDetails);
             if (totalCountOfCartItems == 1)
             {
                var cartHeaderToRemove = await _db.CartHeaders.FirstOrDefaultAsync(u => u.CartHeaderId == cartDetails.CartHeaderId);

                _db.CartHeaders.Remove(cartHeaderToRemove);
                
             }

                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}