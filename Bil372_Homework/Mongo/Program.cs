using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
//using MongoDB.Driver.Builders<TDocument>;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace _372_odev2
{
    class Program
    {
    
        String prev_submission_id   ="";
        String submission_id        ="";
        String title                ="";
        String abstractval          ="";
        String submitted_by         ="";
        String corresponding_author ="";
        String pdf_path             ="";
        String type                 ="";
        String submission_date_time ="";

        String status               ="";
        String active               ="";

        String[] keywords=null;
        String[] authors=null;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Connection creating...");
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            Console.WriteLine("Connection created!");

            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");
            var collection = db.GetCollection<BsonDocument>("submissions");
            Program p = new Program();
            int[] authors = new int[5];
            authors[0]=1233132;
            authors[1]=123213;
            //p.newSubmission(0000003,00000002,0000004,"newresearch4","ACBBCC",authors, "fake4.pdf","economy", "17/09/2020 12:05 GMT+3",0,0);
            //p.newSubmission(0000004,00000001,0000003,"globalresearch","AAABCC",authors, "fake2.pdf","business", "18/01/2020 03:05 GMT+3",0,0);
            //p.updateSubmission(0000002,00000001,0000002,"newglobalresearch","AAABBCC",authors, "newfake2.pdf","medicine", "14/07/2021 12:45 GMT+3");
            //p.inActiveSubmission(0000003);
            //p.recoverSubmission(0000003);
            //p.deleteSubmissionPermanently(0000003);
            //p.displayInfo(true);
            //p.viewSubmission(4);
        }
        void displayInfo(bool isadmin){
            
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
            var documents = collection.Find(new BsonDocument()).ToList();
     
            foreach(BsonDocument doc in documents)
            {
                Console.WriteLine(doc.ToString()+"\n");
            }       
        }

        void inActiveSubmission(int submissionid){
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
            var filter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);
            var update = Builders<BsonDocument>.Update.Set("active", 0); //1=active 0=nonactive
            collection.UpdateOne(filter, update);
            Console.WriteLine("Sucesfully inactived");

        }

        void recoverSubmission(int submissionid){
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
            var filter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);
            var update = Builders<BsonDocument>.Update.Set("active", 1); //1=active 0=nonactive
            collection.UpdateOne(filter, update);
            Console.WriteLine("Sucesfully actived");

        }

        void updateSubmission(int submissionid,int submitter,int cauthor,String title,String abstractval,int[] authorids, String pdfpath,String type, String date){
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
            var filter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);
            var update = Builders<BsonDocument>.Update.Set("title", title);
            var update1 = Builders<BsonDocument>.Update.Set("abstract", abstractval);
            var update2 = Builders<BsonDocument>.Update.Set("authors", authorids);
            var update3 = Builders<BsonDocument>.Update.Set("pdf path", pdfpath);
            var update4 = Builders<BsonDocument>.Update.Set("type", type);
            var update5 = Builders<BsonDocument>.Update.Set("date", date);
            var update6 = Builders<BsonDocument>.Update.Set("status", 0); //status 0=modified ; 1=original
            var update7 = Builders<BsonDocument>.Update.Set("active", 1); //1=active 0=nonactive
            var update8 = Builders<BsonDocument>.Update.Set("submitted by", submitter);

            collection.UpdateOne(filter, update);
            collection.UpdateOne(filter, update1);
            collection.UpdateOne(filter, update2);
            collection.UpdateOne(filter, update3);
            collection.UpdateOne(filter, update4);
            collection.UpdateOne(filter, update5);
            collection.UpdateOne(filter, update6);
            collection.UpdateOne(filter, update7);
            collection.UpdateOne(filter, update8);

            Console.WriteLine("Sucesfully Updated");


        }
        void newSubmission(int submissionid,int submitter,int cauthor,String title,String abstractval,int[] authorids, String pdfpath,String type, String date,int status,int active){


            List<BsonDocument> parts = new List<BsonDocument>();
            BsonArray barray = new BsonArray{};
            for(int i = 0 ; i < authorids.Length; i++){

                //BsonDocument auth = getSubmission(authorids[i]);
                //barray.Add(auth);
            }
            Console.WriteLine("new Submission created");

                        barray.Add(new BsonDocument { { "authenticationID", "001" },{ "name", "Richard Jones" },{ "email", "rjones@gmail.com" },{ "affil", "...." },{ "country", "TURKIYE" } });
                        barray.Add(new BsonDocument { { "authenticationID", "002" },{ "name", "James Jones" },{ "email", "jjones@gmail.com" },{ "affil", "...." },{ "country", "TURKIYE" } });
                        barray.Add(new BsonDocument { { "authenticationID", "003" },{ "name", "Richard Joe" },{ "email", "rj2ones@gmail.com" },{ "affil", "...." },{ "country", "TURKIYE" } });
                        barray.Add(new BsonDocument { { "authenticationID", "004" },{ "name", "Rich Jones" },{ "email", "rj3ones@gmail.com" },{ "affil", "...." },{ "country", "TURKIYE" } });

            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );

            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");
            var collection = db.GetCollection<BsonDocument>("submissions");
            var document = new BsonDocument {
            
                {"prev submission id",submissionid}, //ConfID_
                {"submission id",submissionid},
                {"title", title},
                {"abstract", abstractval},
                //{"keywords" , ["ccccc", "ddddddd", "eeeeeeee"]}, //todo
                {"authors", barray },
                {"submitted by" , submitter}, //AuthenticationID ,
                {"corresponding author" , cauthor}, //AuthenticationID ,
                {"pdf_path" ,pdfpath },
                {"type" , type},
                {"submission date time" , date},  // "12/02/2020 13:05 GMT+3"
                {"status" , status},//1:original or modified
                {"active" , active} //0: no, 1: yes
            };
            collection.InsertOne(document);
        }

        void editSubmission(int submissionid, String colname,String colvalue) {
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
                        
            var filter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);
            var update = Builders<BsonDocument>.Update.Set("{colname}", colvalue);
            collection.UpdateOne(filter, update);



        }

        void deleteSubmissionPermanently(int submissionid){
             MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
            var deleteFilter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);

            collection.DeleteOne(deleteFilter);
            Console.WriteLine("Submission deleted");

        }

        void listCollections(){

             MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );

            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");
            var collection = db.GetCollection<BsonDocument>("submissions");
            
           // var list = collection.FindAll();
            Console.WriteLine(collection);
            Console.WriteLine("Listed Collections");

            
        }

        void viewSubmission(int submissionid){

            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
                        
            var filter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);

            var documents = collection.Find(new BsonDocument()).ToList();
     
            foreach(BsonDocument doc in documents)
            {
                Console.WriteLine(doc.ToString()+"\n");
            }  
            //var ans = collection.Find(filter); 
            //Console.WriteLine(ans.ToString());
        }

        void changeStatus(int submissionid,int status){
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
                        
            var filter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);
            var update = Builders<BsonDocument>.Update.Set("status", status);
            collection.UpdateOne(filter, update);
        }

        void changeActive(int submissionid,int active){
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );
            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");

            var collection = db.GetCollection<BsonDocument>("submissions");
                        
            var filter = Builders<BsonDocument>.Filter.Eq("submission id", submissionid);
            var update = Builders<BsonDocument>.Update.Set("active", active);
            collection.UpdateOne(filter, update);
        }

            String insertPrevSubmissionId(String var){
                prev_submission_id= "{"+ " \"prev submission id\" : \" "+var+"\"}";
                return prev_submission_id;
            }

            String insertSubmissionId(String var){
                submission_id= "{"+ " \"submission id\" : \" "+var+"\"}";
                return submission_id;
            }

            String insertTitle(int var){
                title ="{"+ " \"title\" : \" "+var+"\"}";
                return title;
            }

            String insertAbstract(int var){
                abstractval = "{"+ " \"abstract\" : \" "+var+"\"}";
                return abstractval;
            }

            String insertSubmittedBy(int var){ //authentication id
                submitted_by = "{"+ " \"submitted by\" : \" "+var+"\"}";
                return submitted_by;
            }

            String insertCorrespondingAuthor(String var){ //authentication id
                corresponding_author = "{"+ " \"corresponding author\" : \" "+var+"\"}";
                return corresponding_author;
            }

            String insertPdfPath(String var){
                pdf_path= "{"+ " \"pdf_path\" : \" "+var+"\"}";
                return pdf_path;
            }

            String insertType(String var){
                type = "{"+ " \"type\" : \" "+var+"\"}";
                return type;
            } 

            String insertSubmissionDateTime(String date){ //todo for date
                submission_date_time = "{"+ " \"submission date time\" : \" "+date+"\"}";
                return submission_date_time;
            }  

            String insertStatus(String var){ //1:original or modified
                status = "{"+ " \"status\" : \" "+var+"\"}";
                return status;
            }
            String insertActive(String var){ //0: no, 1: yes
                active = "{"+ " \"active\" : \" "+var+"\"}";
                return active;
            }



/*
            String[] insertAuthors(String[] var){
                authors=var;
                return authors;
            }
            String[] insertKeywords(String[] var){
                keywords=var;
                return keywords;
            }
*/

    }
}
