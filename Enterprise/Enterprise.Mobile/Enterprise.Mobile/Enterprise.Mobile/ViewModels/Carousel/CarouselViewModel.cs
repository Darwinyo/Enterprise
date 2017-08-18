﻿using Enterprise.Mobile.Models.Carousel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Mobile.ViewModels.Carousel
{
    public class CarouselViewModel
    {
        public ObservableCollection<CarouselModel> ProductImages { get; set; }

        public CarouselViewModel()
        {
            ProductImages = new ObservableCollection<CarouselModel>
            {
                new CarouselModel
                {
                    ImageUrl="productimage.png"
                },
                new CarouselModel
                {
                    ImageUrl="productimage.png"
                },
                new CarouselModel
                {
                    ImageUrl="productimage.png"
                },
                new CarouselModel
                {
                    ImageUrl="productimage.png"
                },
                new CarouselModel
                {
                    ImageUrl="productimage.png"
                }
            };
        }
    }
}
