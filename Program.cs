using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TwitterV2PicBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Auth.
            var key = ConfigurationManager.AppSettings["ConsumerAPIKey"];
            var secret = ConfigurationManager.AppSettings["ConsumerSecret"];
            var at = ConfigurationManager.AppSettings["AccessToken"];
            var ats = ConfigurationManager.AppSettings["AccessTokenSecret"];
            TwitterClient UserClient = new TwitterClient(key, secret, at, ats);

            //Connect image.
            byte[] ImageBytes = File.ReadAllBytes("charizard.jpg"); //--\TwitterV2PicBot\bin\Debug\net5.0\"

            IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageBytes);

            //Send image with Parameters.
            ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(
                new PublishTweetParameters("#PokeTest #CuteSalamandar #Salamandar") { Medias = { ImageIMedia } });

        }


    }

}
