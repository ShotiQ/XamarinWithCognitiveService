using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

using Plugin.Media;
using Plugin.Media.Abstractions;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        MediaFile img;
        public TabbedPage1()
        {
            InitializeComponent();
            
        }
        private async void btnCapture_Clicked(object sender, EventArgs e)
        {
            try
            {
                img = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    Name = "photo.jpg"
                });

                imgPic.Source = img.Path;
            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.Message, "ok");
            }
            
        }
        private async void btnFaceAPI_Clicked(object sender, EventArgs e)
        {
            FaceServiceClient cl = new FaceServiceClient("qb76d76b1bd174f36a5f7c4f21d9196e4", "https://southeastasia.api.cognitive.microsoft.com/face/v1.0");

            Face[] faces = await cl.DetectAsync(img.GetStream(), false, false, new FaceAttributeType[] { FaceAttributeType.Age, FaceAttributeType.Gender });

            await DisplayAlert("Face detected!","Gender: " + faces[0].FaceAttributes.Gender + " Age: " + faces[0].FaceAttributes.Age, "Okay");
        }
        private void btnEmotionAPI_Clicked(object sender, EventArgs e)
        {

        }
    }
}