using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neo4jClient;
using PmbokApp.Models;

namespace PmbokApp.Controllers
{
    public class KnowledgeAreaController : Controller
    {
        // GET: KnowledgeArea
        public ActionResult Index()
        {
            return View();
        }

        // GET: KnowledgeArea/Details/AreaId
        public ActionResult Details(string Id)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "sLnB6!+2Ch");
            client.Connect();
            var Result = client.Cypher
                .Match("(ka:KnowlegeArea)")
                .Where((PMKnowledgeArea ka) => ka.Id == Id)
                .Return(ka => ka.As<PMKnowledgeArea>())
                .Results;
            PMKnowledgeArea KnowledgeArea = Result.First();

            // get the processes of knowledge area
            List<PMProcess> Processes = client.Cypher
                .Match("(ka:KnowlegeArea)")
                .Where((PMKnowledgeArea ka) => ka.Id == Id)
                .Match("(p:Process)-[r:BELONGS_TO]->(ka)")
                .Return(p => p.As<PMProcess>())
                .Results.ToList();
            KnowledgeArea.PMProcesses = Processes;

            // get the artefacts of knowledge area
            List<PMArtefact> Artefacts = client.Cypher
                .Match("(ka:KnowlegeArea)")
                .Where((PMKnowledgeArea ka) => ka.Id == Id)
                .Match("(art:Artefact)")
                .Match("(art)-[*1..2]-(pg:ProcessGroup)")
                .Where("(ka)-[*1..2]-(art)")
                .ReturnDistinct((art) => art.As<PMArtefact>())
                .Results.ToList();
            KnowledgeArea.PMArtefacts = Artefacts;

            // get the tools of knowledge area
            List<PMTool> Tools = client.Cypher
                .Match("(ka:KnowlegeArea)")
                .Where((PMKnowledgeArea ka) => ka.Id == Id)
                .Match("(tool:Tool)")
                .Match("(tool)-[*1..3]-(pg:ProcessGroup)")
                .Where("(ka)-[*1..3]-(tool)")
                .ReturnDistinct(tool => tool.As<PMTool>())
                .Results.ToList();
            KnowledgeArea.PMTools = Tools;

            return View(KnowledgeArea);
        }

        // GET: KnowledgeArea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KnowledgeArea/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: KnowledgeArea/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KnowledgeArea/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: KnowledgeArea/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KnowledgeArea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
