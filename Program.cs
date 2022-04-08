using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TwitterV2PicBot
{
    public class Program
    {

        static void Main(string[] args)
        {

            Media();

        }


        public async static void Media()
        {
            //Auth.
            string key = ConfigurationManager.AppSettings["ConsumerAPIKey"];
            string secret = ConfigurationManager.AppSettings["ConsumerSecret"];
            string at = ConfigurationManager.AppSettings["AccessToken"];
            string ats = ConfigurationManager.AppSettings["AccessTokenSecret"];

            TwitterClient UserClient = new TwitterClient(key, secret, at, ats);
            //Connect image.
            byte[] ImageBytes = File.ReadAllBytes("charizard.jpg");

            IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageBytes);

            //Send image with Parameters.
            ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(
                new PublishTweetParameters("#PokeTest #CuteSalamandar #Salamandar") { Medias = { ImageIMedia } });
        }

    }
