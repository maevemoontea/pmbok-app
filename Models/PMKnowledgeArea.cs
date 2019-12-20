using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PmbokApp.Models
{
    public class PMKnowledgeArea
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        // List of processes
        private List<string> _processesTitles;
        private List<PMProcess> _PMProcesses;
        public List<PMProcess> PMProcesses { get { return _PMProcesses; }
            set {
                _PMProcesses = value;
                List<string> result = new List<string>();
                foreach (PMProcess process in PMProcesses)
                {
                    result.Add(process.Title);
                }
                _processesTitles = result;
            } }
        public List<string> ProcessesTitles { 
            get { return _processesTitles; }
        }

        // List of artefacts
        private List<string> _artefactsTitles;
        private List<PMArtefact> _PMArtefacts;
        public List<PMArtefact> PMArtefacts
        {
            get { return _PMArtefacts; }
            set
            {
                _PMArtefacts = value;
                List<string> result = new List<string>();
                foreach (PMArtefact process in PMArtefacts)
                {
                    result.Add(process.Title);
                }
                _artefactsTitles = result;
            }
        }
        public List<string> ArtefactsTitles
        {
            get { return _artefactsTitles; }
        }

        // List of tools
        private List<string> _toolsTitles;
        private List<PMTool> _PMTools;
        public List<PMTool> PMTools
        {
            get { return _PMTools; }
            set
            {
                _PMTools = value;
                List<string> result = new List<string>();
                foreach (PMTool process in PMTools)
                {
                    result.Add(process.Title);
                }
                _toolsTitles = result;
            }
        }
        public List<string> ToolsTitles
        {
            get { return _toolsTitles; }
        }
    }
}