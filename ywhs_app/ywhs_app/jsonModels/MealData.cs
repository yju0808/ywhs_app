using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ywhs_app.jsonModels.meal
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class RESULT
    {
        [JsonProperty("CODE")]
        public string CODE { get; set; }

        [JsonProperty("MESSAGE")]
        public string MESSAGE { get; set; }
    }

    public class Head
    {
        [JsonProperty("list_total_count")]
        public int ListTotalCount { get; set; }

        [JsonProperty("RESULT")]
        public RESULT RESULT { get; set; }

        public Head()
        {
            RESULT = new RESULT();
        }
    }

    public class Row
    {
        [JsonProperty("ATPT_OFCDC_SC_CODE")]
        public string ATPTOFCDCSCCODE { get; set; }

        [JsonProperty("ATPT_OFCDC_SC_NM")]
        public string ATPTOFCDCSCNM { get; set; }

        [JsonProperty("SD_SCHUL_CODE")]
        public string SDSCHULCODE { get; set; }

        [JsonProperty("SCHUL_NM")]
        public string SCHULNM { get; set; }

        [JsonProperty("MMEAL_SC_CODE")]
        public string MMEALSCCODE { get; set; }

        [JsonProperty("MMEAL_SC_NM")]
        public string MMEALSCNM { get; set; }

        [JsonProperty("MLSV_YMD")]
        public string MLSVYMD { get; set; }

        [JsonProperty("MLSV_FGR")]
        public string MLSVFGR { get; set; }

        [JsonProperty("DDISH_NM")]
        public string DDISHNM { get; set; }

        [JsonProperty("ORPLC_INFO")]
        public string ORPLCINFO { get; set; }

        [JsonProperty("CAL_INFO")]
        public string CALINFO { get; set; }

        [JsonProperty("NTR_INFO")]
        public string NTRINFO { get; set; }

        [JsonProperty("MLSV_FROM_YMD")]
        public string MLSVFROMYMD { get; set; }

        [JsonProperty("MLSV_TO_YMD")]
        public string MLSVTOYMD { get; set; }
    }

    public class MealServiceDietInfo
    {
        [JsonProperty("head")]
        public List<Head> Head { get; set; }

        [JsonProperty("row")]
        public List<Row> Row { get; set; }

        public MealServiceDietInfo()
        {
            Head = new List<Head>();
            Row = new List<Row>();
        }
    }

    public class MealData
    {
        [JsonProperty("mealServiceDietInfo")]
        public List<MealServiceDietInfo> MealServiceDietInfo { get; set; }

        public MealData()
        {
            MealServiceDietInfo = new List<MealServiceDietInfo>();
        }
    }


}
