﻿using System.Collections.Generic;
using Microsoft.Office.Interop.PowerPoint;
using PowerPointLabs.PictureSlidesLab.Model;
using PowerPointLabs.PictureSlidesLab.Service.StylesWorker.Interface;

namespace PowerPointLabs.PictureSlidesLab.Service.StylesWorker
{
    class BannerStyleWorker : IStyleWorker
    {
        public IList<Shape> Execute(StyleOption option, EffectsDesigner designer, ImageItem source, Shape imageShape)
        {
            var result = new List<Shape>();
            if (option.IsUseBannerStyle)
            {
                var bannerOverlayShape = ApplyBannerStyle(option, designer, imageShape);
                result.Add(bannerOverlayShape);
            }
            return result;
        }

        private Shape ApplyBannerStyle(StyleOption option, EffectsDesigner effectsDesigner, Shape imageShape)
        {
            return effectsDesigner.ApplyRectBannerEffect(option.GetBannerDirection(), option.GetTextBoxPosition(),
                        imageShape, option.BannerColor, option.BannerTransparency);
        }
    }
}
