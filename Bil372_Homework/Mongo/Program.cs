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

            void addSubmission(){
                
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
}
