using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ywhs_app.jsonModels.schedule
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class RESULT
    {
        public string CODE { get; set; }
        public string MESSAGE { get; set; }
    }

    public class Head
    {
        public int list_total_count { get; set; }

        [JsonProperty("RESULT")]
        public RESULT result { get; set; }

        public Head()
        {
            result = new RESULT();
        }


    }

    public class Row
    {
        public string ATPT_OFCDC_SC_CODE { get; set; }
        public string ATPT_OFCDC_SC_NM { get; set; }
        public string SD_SCHUL_CODE { get; set; }
        public string SCHUL_NM { get; set; }
        public string AY { get; set; }
        public string DGHT_CRSE_SC_NM { get; set; }
        public string SCHUL_CRSE_SC_NM { get; set; }
        public string SBTR_DD_SC_NM { get; set; }
        public string AA_YMD { get; set; }
        public string EVENT_NM { get; set; }
        public object EVENT_CNTNT { get; set; }
        public string ONE_GRADE_EVENT_YN { get; set; }
        public string TW_GRADE_EVENT_YN { get; set; }
        public string THREE_GRADE_EVENT_YN { get; set; }
        public string FR_GRADE_EVENT_YN { get; set; }
        public string FIV_GRADE_EVENT_YN { get; set; }
        public string SIX_GRADE_EVENT_YN { get; set; }
        public string LOAD_DTM { get; set; }
    }

    public class SchoolSchedule
    {
        public List<Head> head { get; set; }
        public List<Row> row { get; set; }

        public SchoolSchedule()
        {
            head = new List<Head>();
            row = new List<Row>();
        }
    }

    public class ScheduleData
    {
        public List<SchoolSchedule> SchoolSchedule { get; set; }

        public ScheduleData()
        {
            SchoolSchedule = new List<SchoolSchedule>();
        }
    }


}
