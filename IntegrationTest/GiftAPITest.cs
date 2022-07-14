using API;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using AutoFixture;
using System.Linq;

namespace IntegrationTest
{
    public class GiftAPITest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        public GiftAPITest(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task GenerateGiftCodes()
        {
            Fixture AutoData = new Fixture();
            var webClient = webApplicationFactory.CreateClient();
            webClient.DefaultRequestHeaders.Add("Authorization"
                , "Bearer " + SwtTokenService.JwtGenerator(Guid.NewGuid().ToString()));
            var gift = new GiftAPI("http://localhost:5000/", webClient);
           
            try
            {
                var result = await gift.GenerategiftcodeAsync(new GenerateGiftCodeViewModel()
                {
                    GiftID = "12378738912783782197893721983789127837839821798321",
                    HowMany=10,
                    Length=5,
                    Rules="Nothing"
                }) ;

                Assert.False(false);
            }
            catch (Exception Ex)
            {
                Assert.False(true,Ex.Message);
            }
        }
        [Fact]
        public async Task UsedGiftCode()
        {
            Fixture AutoData = new Fixture();
            var webClient = webApplicationFactory.CreateClient();
            webClient.DefaultRequestHeaders.Add("Authorization"
                , "Bearer " + SwtTokenService.JwtGenerator(Guid.NewGuid().ToString()));
            var gift = new GiftAPI("http://localhost:5000/", webClient);

            try
            {
                var result = await gift.Usinggift2Async(new UsingGiftCodeViewModel() 
                {
                    GiftCodeValue= "17576"
                });

                Assert.False(false);
            }
            catch (Exception Ex)
            {
                Assert.False(true, Ex.Message);
            }
        }
        [Fact]
        public async Task GetGiftCodeList()
        {
            Fixture AutoData = new Fixture();
            var webClient = webApplicationFactory.CreateClient();
            webClient.DefaultRequestHeaders.Add("Authorization"
                , "Bearer " + SwtTokenService.JwtGenerator(Guid.NewGuid().ToString()));
            var gift = new GiftAPI("http://localhost:5000/", webClient);

            try
            {
                var result = await gift.GiftcodeAllAsync
                    ("12378738912783782197893721983789127837839821798321");

                Assert.Equal(10, result.Count);
            }
            catch (Exception Ex)
            {
                Assert.False(true, Ex.Message);
            }
        }
        [Fact]
        public async Task DeleteGiftCode()
        {
            Fixture AutoData = new Fixture();
            var webClient = webApplicationFactory.CreateClient();
            webClient.DefaultRequestHeaders.Add("Authorization"
                , "Bearer " + SwtTokenService.JwtGenerator(Guid.NewGuid().ToString()));
            var gift = new GiftAPI("http://localhost:5000/", webClient);

            try
            {
                var result = await gift.GiftcodeAsync(new UsingGiftCodeViewModel() 
                {
                    GiftCodeValue= "63827"
                });

                Assert.False(false);
            }
            catch (Exception Ex)
            {
                Assert.False(true, Ex.Message);
            }
        }
        [Fact]
        public async Task CreateGift() 
        {
            Fixture AutoData = new Fixture();
            var webClient = webApplicationFactory.CreateClient();
            webClient.DefaultRequestHeaders.Add("Authorization"
                , "Bearer " + SwtTokenService.JwtGenerator(Guid.NewGuid().ToString()));
            var gift = new GiftAPI("http://localhost:5000/", webClient);

            try
            {
                var result = await gift.BasketgiftPOSTAsync(
                    new BasketGiftCommandViewModel() 
                    {
                        Title="Gift",
                        UsabilityCount=1,
                        Image=new Image() 
                        {
                            ImageAddress= AutoData.Create<string>() + ".jpg",
                            ImageTitle=AutoData.Create<string>()
                        },
                        AppliedEvent= "DirectlyForAllUsers",
                        Description="Good Gift",
                        ExpireDate=DateTime.Now.AddDays(10),
                        GeneralGiftCode="GoodDay",
                        GiftType="Percentage",
                        MinBasket=50,
                        Value=20,
                        Accessibility="Public"
                    });

                Assert.False(false);
            }
            catch (Exception Ex)
            {
                Assert.False(true, Ex.Message);
            }
        }
        [Fact]
        public async Task UsedGift()
        {
            Fixture AutoData = new Fixture();
            var webClient = webApplicationFactory.CreateClient();
            webClient.DefaultRequestHeaders.Add("Authorization"
                , "Bearer " + SwtTokenService.JwtGenerator(Guid.NewGuid().ToString()));
            var gift = new GiftAPI("http://localhost:5000/", webClient);

            try
            {
                var result = await gift.UsinggiftAsync(new UsingGiftViewModel()
                {
                    Id= "715895c2-3bb7-4c44-abd3-f8bdf8ce3120"
                });

                Assert.False(false);
            }
            catch (Exception Ex)
            {
                Assert.False(true, Ex.Message);
            }
        }

    }

}
