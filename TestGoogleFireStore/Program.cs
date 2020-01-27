using Google.Apis.Auth.OAuth2;
using System;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Core;
using Grpc.Auth;

namespace TestGoogleFireStore
{
    partial class Program
    {


        static void Main(string[] args)
        {


            string project = "YOUR_PROJECT_ID";


            GoogleCredential cred = GoogleCredential.FromFile(@"C:\[YOUR_PATH]\[YOUR_FILE].json");
            Channel channel = new Channel(FirestoreClient.DefaultEndpoint.Host,
                          FirestoreClient.DefaultEndpoint.Port,
                          cred.ToChannelCredentials());
            FirestoreClient client = FirestoreClient.Create(channel);
            FirestoreDb db = FirestoreDb.Create(project, client);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", project);

            //GoogleApiImplement.callAddDataHelper(db);
            FireStoreApiImplementation.callRetrieveDataHelper(db);


            Console.ReadLine();

        }
    }
}






