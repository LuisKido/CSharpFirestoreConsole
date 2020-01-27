using System;
using Google.Cloud.Firestore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestGoogleFireStore
{
    partial class Program
    {
        public static class FireStoreApiImplementation
        {

            public static async void callAddDataHelper(FirestoreDb db)
            {
                await AddData1(db);
            }

            public static async Task AddData1(FirestoreDb db)
            {
                //FirestoreDb db = FirestoreDb.Create(project);

                DocumentReference docRef = db.Collection("users").Document("aturing");
                Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "First", "Alan" },
                    { "Middle", "Mathison" },
                    { "Last", "Turing" },
                    { "Born", 1912 }
                };
                await docRef.SetAsync(user);
                Console.WriteLine("Added data to the alovelace document in the users collection.");
            }

            public static async void callRetrieveDataHelper(FirestoreDb db)
            {
                await RetrieveAllDocuments(db);
            }

            private static async Task RetrieveAllDocuments(FirestoreDb db)
            {
                //FirestoreDb db = FirestoreDb.Create(project);
                CollectionReference usersRef = db.Collection("users");
                QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    Console.WriteLine("User: {0}", document.Id);
                    Dictionary<string, object> documentDictionary = document.ToDictionary();
                    Console.WriteLine("First: {0}", documentDictionary["First"]);
                    if (documentDictionary.ContainsKey("Middle"))
                    {
                        Console.WriteLine("Middle: {0}", documentDictionary["Middle"]);
                    }
                    Console.WriteLine("Last: {0}", documentDictionary["Last"]);
                    Console.WriteLine("Born: {0}", documentDictionary["Born"]);
                    Console.WriteLine();
                }
            }
        }
    }
}






