using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _contex;

        public FollowingsController()
        {
            _contex = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var followerId = User.Identity.GetUserId();
            var isFollowing = _contex.Followings.Any(f => f.FollowerId == followerId && f.FolloweeId == dto.FolloweeId);
            if (isFollowing)
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = followerId,
                FolloweeId = dto.FolloweeId
            };

            _contex.Followings.Add(following);
            _contex.SaveChanges();

            return Ok();
        }
    }
}
