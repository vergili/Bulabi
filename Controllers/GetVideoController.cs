using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bulabi.Domain.Abstract;
using bulabi.Domain.Entities;

namespace bulabi.WebUI.Controllers
{
    [Authorize]
    public class GetVideoController : Controller
    {
       
        private IVideoRepository videoRepository;

        public GetVideoController(IVideoRepository videoRepo)
        {
            videoRepository = videoRepo;
        }


        public ViewResult Index()
        {
            return View(videoRepository.Videos);
        }

        public ViewResult Edit(int videoId)
        {
            Video video = videoRepository.Videos
                .FirstOrDefault(p => p.VideoID == videoId);
            return View(video);
        }

        [HttpPost]
        public ActionResult Edit(Video video)
        {
            if (ModelState.IsValid)
            {
                videoRepository.SaveVideo(video);
                TempData["message"] = string.Format("{0} has been saved", video.Title);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(video);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Video());
        }

        [HttpPost]
        public ActionResult Delete(int videoId)
        {
            Video deletedVideo = videoRepository.DeleteVideo(videoId);
            if (deletedVideo != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deletedVideo.Title);
            }
            return RedirectToAction("GetVideoIndex");
        }

    }
}
