using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neo4jClient;
using PmbokApp.Models;

namespace PmbokApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "List of PM knowledge areas";
            ViewBag.Message = "Total 10 areas defined by PMBoK";
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "sLnB6!+2Ch");
            client.Connect();
            var KnowledgeAreas = client.Cypher
                .Match("(ka:KnowlegeArea)")
                .Return(ka => ka.As<PMKnowledgeArea>())
                .Limit(10)
                .Results;
            ViewBag.KnowledgeAreas = KnowledgeAreas;
            return View();
        }

    }
}