using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.Mobile.Models.ProductDetails;

namespace Enterprise.Mobile.ViewModels.ProductDetails
{
    public class ProductDetailsViewModel:BaseViewModel
    {
        public ProductDetailsViewModel()
        {
            ProductSpecs= new List<ProductSpecsModel>
            {
                new ProductSpecsModel{ItemTitle="Category",ItemValue="Computer Parts"},
                new ProductSpecsModel{ItemTitle="Dimension",ItemValue="20x20x20"},
                new ProductSpecsModel{ItemTitle="Condition",ItemValue="New"},
                new ProductSpecsModel{ItemTitle="Manufacturer",ItemValue="Intel/AMD"},
            };
            Description = "Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit. Mauris rutrum volutpat massa, sed tincidunt tortor facilisis id. Duis magna nisl," +
                " mollis quis convallis vel, ornare nec orci. Nunc id ultricies ligula. Integer purus purus, tempor a accumsan gravida," +
                " laoreet vel justo. Etiam feugiat dolor dolor, in mattis nulla gravida sed. Nulla ut felis nulla." +
                " Fusce malesuada orci eu velit sollicitudin commodo. Praesent quis est at lorem mattis tincidunt." +
                " Vivamus non velit eget urna euismod viverra in aliquet enim.Nunc ligula est, imperdiet eget neque vitae," +
                " semper vestibulum quam.Phasellus vehicula faucibus urna, eget consequat est pharetra quis.Morbi in dolor in tortor vulputate pharetra" +
                " a non velit.Nullam nec erat a ante pharetra feugiat non tempus est.Maecenas fringilla semper mauris eget porta.Suspendisse eu purus" +
                " lacinia, laoreet urna at, fermentum arcu.Integer mollis massa felis, sit amet pharetra velit imperdiet sed.Duis sit amet porttitor felis" +
                ".Nam urna libero, luctus in mollis sit amet, vestibulum vel lorem.Vestibulum pharetra aliquam ipsum vel maximus.Etiam sit amet metus ut est" +
                " porttitor ornare id a lorem.Ut vitae justo nec orci sollicitudin malesuada sed sed sem.Donec ut erat viverra turpis egestas condimentum in ut" +
                " tellus.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Vestibulum imperdiet quis justo eget ultrices." +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Donec pretium a augue ac interdum.Maecenas leo velit, vulputate vitae ligula id, blandit" +
                " bibendum metus.Cras rhoncus ligula eu ex bibendum consectetur.Praesent id nisi tristique, commodo mi sodales, gravida erat.Donec pulvinar molestie" +
                " vulputate.Suspendisse tincidunt blandit mauris vel malesuada.Ut tempus quam vitae ultrices rutrum.Nullam facilisis facilisis condimentum.Sed sit amet" +
                " diam a urna vulputate lobortis.Morbi in convallis dolor.Cras congue arcu nunc, vel venenatis lacus lacinia nec.Proin rhoncus nibh id feugiat aliquet." +
                "Donec vel aliquam ante.Suspendisse non ultrices lectus.Morbi augue libero, aliquam a libero sit amet, faucibus rhoncus sem.Curabitur sit amet pharetra " +
                "est, eu tristique nisi.In varius commodo urna.Duis non ipsum laoreet, facilisis erat sed, faucibus turpis.Maecenas urna dolor, blandit a nunc ut, auctor" +
                " bibendum dolor.Donec sit amet ipsum quam.Proin vitae quam at ante fringilla fermentum."
                ;
            TitleDescription = "CPU Description";
        }
        public ProductDetailsViewModel(string description,string titledescription,List<ProductSpecsModel> productspecs)
        {
            Description = description;
            TitleDescription = titledescription;
            ProductSpecs = productspecs;
        }
        string description, titleDescription;
        List<ProductSpecsModel> productSpecs;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                SetProperty(ref description, value);
            }
        }
        public string TitleDescription
        {
            get
            {
                return titleDescription;
            }
            set
            {
                SetProperty(ref titleDescription, value);
            }
        }
        public List<ProductSpecsModel> ProductSpecs
        {
            get
            {
                return productSpecs;
            }
            set
            {
                SetProperty(ref productSpecs, value);
            }
        }
    }
}
