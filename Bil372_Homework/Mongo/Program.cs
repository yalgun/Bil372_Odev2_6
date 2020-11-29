using System;

using MongoDB.Bson;
using MongoDB.Driver;
 
namespace _372_odev2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MongoClient dbClient = new MongoClient(
                
                "mongodb+srv://admin:1234@bil372cluster.aut1j.mongodb.net/makaledatabase?retryWrites=true&w=majority"
            
            );

            IMongoDatabase db = dbClient.GetDatabase("makaledatabase");
            var makale_adi = db.GetCollection<BsonDocument>("makale_adi");
            var firstDocument = makale_adi.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());

            var submissions = db.GetCollection<BsonDocument>("submissions");
            /*
            submissions.InsertOne(new BsonDocument
            {
                    {"prev submission id","Yunus"},
                    {"submission id","Kaygun"},
                    {"title",25},
                    {"abstract", 123456},
                    {"keywords" : ["ccccc", "ddddddd", "eeeeeeee"]},
                    {"authors”:[
                                {"authenticationID": " " ,"name": "Richard Jones", "email": "…………", "affil": "………..", "country": " "},
                                {"authenticationID": " " ,"name": "Richard Jones", "email": "…………", "affil": "………..", "country": " "},
                                {"authenticationID": " " ,"name": "Richard Jones", "email": "…………", "affil": "………..", "country": " "},
                                {"authenticationID": " " ,"name": "Richard Jones", "email": "…………", "affil": "………..", "country": " "},
                                {"authenticationID": " " ,"name": "Richard Jones", "email": "…………", "affil": "………..", "country": " "},
                                {"authenticationID": " " ,"name": "Richard Jones", "email": "…………", "affil": "………..", "country": " "}, //Authentication id ever kayıtlı degilse bostur.
                    ]},

                    {"submitted by" : " "}, //AuthenticationID ,

                    {"corresponding author" : " "}, //AuthenticationID ,

                    {"pdf_path" : " " },

                    {"type": "article"},

                    {"submission date time": "12/02/2020 13:05 GMT+3"},

                    {"status" : " "},//1:original or modified

                    {"active" : " "} //0: no, 1: yes

            });
            */
            int prev_submission_id=0;
            int submission_id=0;
            String title="";
            String abstractval="";
            String[] keywords=null;
            String[] authors=null;
            String insertPrevSubmissionId(int var){
                prev_submission_id=var;
                return ""+prev_submission_id;
            }
            String insertSubmissionId(int var){
                submission_id=var;
                return ""+submission_id;
            }
            String insertTitle(String var){
                title =var;
                return title;
            }
            String insertAbstract(String var){
                abstractval=var;
                return abstractval;
            }
            String[] insertAuthors(String[] var){
                authors=var;
                return authors;
            }
            String[] insertKeywords(String[] var){
                keywords=var;
                return keywords;
            }
            /*
            String insertSubmittedBy(){

                return "";
            }
            String insertCorrespondingAuthor(){

                return "";
            }
            String insertPdfPath(){

                return "";
            }
            String insertType(){

                return "";
            }     
            String insertSubmissionDateTime(){

                return "";
            }       
            String insertStatus(){

                return "";
            }
            String insertActive(){

                return "";
            }
            */
        }

    }
}
