﻿using static TMKStore.Responses.CustomResponses;
using TMKStore.DTOs;
using TMKStore.Repos;
using TMKStore.Models;

namespace TMKStore.Services
{
    public class CartService : ICart
    {
        private readonly HttpClient httpClient;

        public CartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private const string BaseUrl = "api/cart";

        public Task<List<Cart>> GetAllCartProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cart>> GetCartByIdUserAsync(Guid userId)
        {
            var cart = await httpClient.GetAsync($"{BaseUrl}/user/{userId}");
            var response = await cart.Content.ReadFromJsonAsync<List<Cart>>();
            return response!;
        }

        public async Task<CartResponse> AddCartProductAsync(Guid userId, Guid productId, int productCount)
        {
            var seriliazeValue = new List<Guid>();
            seriliazeValue.Add(userId);
            seriliazeValue.Add(productId);

            var cart = await httpClient.PostAsJsonAsync($"{BaseUrl}/add", seriliazeValue);
            var response = await cart.Content.ReadFromJsonAsync<CartResponse>();
            return response!;
        }

        public async Task<bool> GetCartProductByIdAsync(Guid productId)
        {
            var cart = await httpClient.GetAsync($"{BaseUrl}/product/{productId}");
            var response = await cart.Content.ReadFromJsonAsync<bool>();
            return response!;
        }

        public async Task<CartResponse> DeleteCartProductAsync(Guid cartId)
        {
            var cart = await httpClient.GetAsync($"{BaseUrl}/delete/{cartId}");
            var response = await cart.Content.ReadFromJsonAsync<CartResponse>();
            return response!;
        }

        public async Task<CartResponse> UpdateCartRecordAsync(Guid cartId, int updateCount)
        {
            var cart = await httpClient.GetAsync($"{BaseUrl}/update/{cartId}");
            var response = await cart.Content.ReadFromJsonAsync<CartResponse>();
            return response!;
        }
    }
}
