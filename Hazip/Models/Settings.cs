using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Settings
    {
        /*
         Ds_Rev	:	28
Analysis_Mode	:	CauseConsequence
Lopa_Mode	:	Implicit
	Column_Widths		{92}
Encrypt	:	false
	Numbering		{8}
Study_Library_Id	:	
	Column_Visibility		{31}
	Column_Headers		{31}
	Tab_Visibility		{9}
Presenter_Mode	:	false
*/
        public string Ds_Rev { get; set; }
        public string Analysis_Mode { get; set; }
        public string Lopa_Mode { get; set; }
        public Column_Widths Column_Widths { get; set; }
        public bool Encrypt { get; set; }
        public Numbering Numbering { get; set; }
        public string Study_Library_Id { get; set; }
        public Column_Visibility Visibility { get; set; }

        public Column_Headers Column_Headers { get; set; }

        public Tab_Visibility Tab_Visibility { get; set; }
        public bool Presenter_Mode { get; set; }

    }
    public class Column_Widths
    {
      
        public string Name { get; set; }
        public string Company	{get; set;}
        public string Title	{get; set;}
        public string Department	{get; set;}
        public string Expertise	{get; set;}
        public string Experience	{get; set;}
        public string Team_Member_Comments	{get; set;}
        public string Date	{get; set;}
        public string Duration	{get; set;}
        public string Session	{get; set;}
        public string Facilitator_ID	{get; set;}
        public string Scribe_ID	{get; set;}
        public string Session_Comments	{get; set;}
        public string Drawing	{get; set;}
        public string Revision	{get; set;}
        public string Document_Type	{get; set;}
        public string Drawing_Description	{get; set;}
        public string Link	{get; set;}
        public string Start_Date	{get; set;}
        public string End_Date	{get; set;}
        public string Revalidation_Comments	{get; set;}
        public string Node_Description	{get; set;}
        public string Intention	{get; set;}
        public string Boundary	{get; set;}
        public string Design_Conditions	{get; set;}
        public string Operating_Conditions	{get; set;}
        public string Node_Color	{get; set;}
        public string Node_Comments	{get; set;}
        public string Deviation	{get; set;}
        public string Guide_Word	{get; set;}
        public string Parameter	{get; set;}
        public string Design_Intent	{get; set;}
        public string Deviation_Comments	{get; set;}
        public string Cause	{get; set;}
        public string Consequence	{get; set;}
        public string Consequence_Type_ID	{get; set;}
        public string Consequence_Severity_ID_Before_Safeguards	{get; set;}
        public string Likelihood_ID_Before_Safeguards	{get; set;}
        public string Risk_Rank_ID_Before_Safeguards	{get; set;}
        public string Safeguard	{get; set;}
        public string Is_Ipl	{get; set;}
        public string Consequence_Severity_ID	{get; set;}
        public string Likelihood_ID	{get; set;}
        public string Risk_Rank_ID	{get; set;}
        public string Lopa_Required	{get; set;}
        public string Pha_Recommendation	{get; set;}
        public string Consequence_Severity_ID_After_Recommendations	{get; set;}
        public string Likelihood_ID_After_Recommendations	{get; set;}
        public string Risk_Rank_ID_After_Recommendations	{get; set;}
        public string Pha_Comment	{get; set;}
        public string Code	{get; set;}
        public string RM_Description	{get; set;}
        public string Color	{get; set;}
        public string Priority	{get; set;}
        public string Required_Lopa_Credits	{get; set;}
        public string Frequency	{get; set;}
        public string RM_Tmel	{get; set;}
        public string Safeguard_Independent	{get; set;}
        public string Safeguard_Auditable	{get; set;}
        public string Safeguard_Effective	{get; set;}
        public string Ipl_Credit	{get; set;}
        public string reference	{get; set;}
        public string Pha_Recommendation_Priority	{get; set;}
        public string Pha_Recommendation_Responsible_Party	{get; set;}
        public string Pha_Recommendation_Status	{get; set;}
        public string Pha_Recommendation_Comments	{get; set;}
        public string Check_List_Description	{get; set;}
        public string Completed_Questions	{get; set;}
        public string Total_Questions	{get; set;}
        public string Percent_Complete	{get; set;}
        public string Check_List_Comments	{get; set;}
        public string Parking_Lot_Issue	{get; set;}
        public string Response	{get; set;}
        public string Responsible_Party	{get; set;}
        public string Lopa_Recommendation	{get; set;}
        public string Lopa_Recommendation_Priority	{get; set;}
        public string Lopa_Recommendation_Responsible_Party	{get; set;}
        public string Lopa_Recommendation_Status	{get; set;}
        public string Lopa_Recommendation_Comments	{get; set;}
        public string Check_List_Recommendation	{get; set;}
        public string Check_List_Recommendation_Priority	{get; set;}
        public string Check_List_Recommendation_Responsible_Party	{get; set;}
        public string Check_List_Recommendation_Status	{get; set;}
        public string Check_List_Recommendation_Comments	{get; set;}
        public string Check_List_Question	{get; set;}
        public string Check_List_Answer	{get; set;}
        public string Check_List_Justification	{get; set;}
        public string Phone_Number	{get; set;}
        public string E__Mail_Address	{get; set;}
        public string Lopa_Risk_Rank_ID	{get; set;}
        public string Lopa_Gap	{get; set;}
        public string Lopa_Comment	{get; set;}

    }

    public class Numbering
    {
        /**Nodes	:	true
Deviations	:	true
Consequences	:	true
Causes	:	true
Safeguards	:	true
Pha_Recommendations	:	true
Lopa_Recommendations	:	true
Parking_Lot	:	true
*/
        public bool Nodes { get; set; }
        public bool Deviations	{get; set;}
        public bool Consequences	{get; set;}
        public bool Causes	{get; set;}
        public bool Safeguards	{get; set;}
        public bool Pha_Recommendations	{get; set;}
        public bool Lopa_Recommendations	{get; set;}
        public bool Parking_Lot {get; set;}
    }

    public class Column_Visibility
    {
        /*Overview	:	true
    Settings	:	true
    Team_Members	:	true
    Sessions	:	true
    Team_Members_Sessions	:	true
    Revalidation_History	:	true
    Nodes	:	true
    Safeguards	:	true
    Pha_Recommendations	:	true
    Pha_Comments	:	true
    Lopa_Recommendations	:	true
    Lopa_Comments	:	true
    Parking_Lot	:	true
    Drawings	:	true
    Risk_Criteria	:	true
    Check_Lists	:	true
    Check_List_Recommendations	:	true*/
    public bool Overview { get; set; }
    public bool Settings	{get; set;}
    public bool Team_Members	{get; set;}
    public bool Sessions	{get; set;}
    public bool Team_Members_Sessions	{get; set;}
    public bool Revalidation_History	{get; set;}
    public bool Nodes	{get; set;}
    public bool Safeguards	{get; set;}
    public bool Pha_Recommendations	{get; set;}
    public bool Pha_Comments	{get; set;}
    public bool Lopa_Recommendations	{get; set;}
    public bool Lopa_Comments	{get; set;}
    public bool Parking_Lot	{get; set;}
    public bool Drawings	{get; set;}
    public bool Risk_Criteria	{get; set;}
    public bool Check_Lists	{get; set;}
    public bool Check_List_Recommendations	{get; set;}
    }

    public class Column_Headers
    {
        /*Overview	:	
Settings	:	
Team_Members	:	
Sessions	:	
Team_Members_Sessions	:	
Revalidation_History	:	
Nodes	:	
Safeguards	:	
Pha_Recommendations	:	
Pha_Comments	:	
Lopa_Recommendations	:	
Lopa_Comments	:	
Parking_Lot	:	
Drawings	:	
Risk_Criteria	:	
Check_Lists	:	
Check_List_Recommendations	:*/

        public string Overview { get; set; }
        public string Settings	{get; set; }
        public string Team_Members	{get; set; }
        public string Sessions	{get; set; }
        public string Team_Members_Sessions	{get; set; }
        public string Revalidation_History	{get; set; }
        public string Nodes	{get; set; }
        public string Safeguards	{get; set; }
        public string Pha_Recommendations	{get; set; }
        public string Pha_Comments	{get; set; }
        public string Lopa_Recommendations	{get; set; }
        public string Lopa_Comments	{get; set; }
        public string Parking_Lot	{get; set; }
        public string Drawings	{get; set; }
        public string Risk_Criteria	{get; set; }
        public string Check_Lists	{get; set; }
        public string Check_List_Recommendations	{get; set; }

        public Overview_Children Overview_Children { get; set; }
        public Team_Members_Children Team_Members_Children { get; set; }
        public Sessions_Children Sessions_Children { get; set; }
        public Revalidation_History_Children Revalidation_History_Children { get; set; }
        public Nodes_Children Nodes_Children { get; set; }
        public Safeguards_Children Safeguards_Children { get; set; }
        public Pha_Recommendations_Children pha_Recommendations_Children { get; set; }
        public Pha_Comments_Children pha_Comments_Children { get; set; }
        public Lopa_Recommendations_Children lopa_Recommendations_Children { get; set; }
        public Lopa_Comments_Children lopa_Comments_Children { get; set; }
        public Parking_Lot_Children Parking_Lot_Children { get; set; }
        public Drawings_Children drawings_Children { get; set; }
        public Check_Lists_Children Check_Lists_Children { get; set; }
        public Check_List_Recommendations_Children Check_List_Recommendations_Children { get; set; }


    }
    public class Overview_Children
    {
  
        public string Study_Name { get; set; }
        public string Study_Coordinator	{get; set;}
        public string Study_Coordinator_Contact_Info	{get; set;}
        public string Facility	{get; set;}
        public string Facility_Location	{get; set;}
        public string Facility_Owner	{get; set;}
        public string Overview_Company	{get; set;}
        public string Site	{get; set;}
        public string Plant	{get; set;}
        public string Unit__Group	{get; set;}
        public string Unit	{get; set;}
        public string Sub__Unit	{get; set;}
        public string Report_Number	{get; set;}
        public string Project_Number	{get; set;}
        public string Project_Description	{get; set;}
        public string General_Notes	{get; set;}

    }

    public class Team_Members_Children
    {
        public string Name { get; set; }
        public string Company	{get; set;}
        public string Title	{get; set;}
        public string Department	{get; set;}
        public string Expertise	{get; set;}
        public string Experience	{get; set;}
        public string Phone_Number	{get; set;}
        public string E__Mail_Address	{get; set;}
        public string Team_Member_Comments{get; set;}
    }
    
    public class Sessions_Children
    {
       public string Date	{get; set;}
       public string Duration	{get; set;}
       public string Session	{get; set;}
       public string Facilitator_ID	{get; set;}
       public string Scribe_ID	{get; set;}
       public string Session_Comments { get; set; }

    }

    public class Revalidation_History_Children
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Revalidation_Comment { get; set; }
    }

    public class Nodes_Children
    {
        public string Node_Description { get; set; }
        public string Intention	{get; set;}
        public string Boundary	{get; set;}
        public string Design_Conditions	{get; set;}
        public string Operating_Conditions	{get; set;}
        public string Node_Color	{get; set;}
        public string Hazardous_Materials	{get; set;}
        public string Equipment_Tags	{get; set;}
        public string Location	{get; set;}
        public string Node_Comments	{get; set;}
        public string Session_IDs	{get; set;}
        public string Drawing_IDs	{get; set;}
        public string Deviations	{get; set;}
    }

    public class Safeguards_Children {
        public string Safeguard { get; set; }
        public string Safeguard_Type	{get; set;}
        public string Safeguard_Independent	{get; set;}
        public string Safeguard_Auditable	{get; set;}
        public string Safeguard_Effective	{get; set;}
        public string Safeguard_Hackable	{get; set;}
        public string Is_Safeguard	{get; set;}
        public string Is_Ipl	{get; set;}
        public string Ipl_Tag	{get; set;}
        public string Safety_Critical	{get; set;}
        public string Selected_Sil	{get; set;}
        public string Required_Response_Time	{get; set;}
        public string Test_Interval	{get; set;}
        public string Safeguard_Library_Id	{get; set;}
        public string Ipl_Credit	{get; set;}
        public string Safeguard_Category	{get; set;}
        public string Safeguard_Comments{get; set;}
    }

    public class Pha_Recommendations_Children
    {
        public string Pha_Recommendation { get; set; }
        public string Pha_Recommendation_Priority	{get;set;}
        public string Pha_Recommendation_Responsible_Party	{get;set;}
        public string Pha_Recommendation_Status	{get;set;}
        public string Pha_Recommendation_Comments{get;set;}
    }

    public class Pha_Comments_Children {
        public string Pha_Comment { get; set;}
    }

    public class Lopa_Recommendations_Children
    {
        public string Lopa_Recommendation	{get; set;}
        public string Lopa_Recommendation_Priority	{get; set;}
        public string Lopa_Recommendation_Responsible_Party	{get; set;}
        public string Lopa_Recommendation_Status	{get; set;}
        public string Lopa_Recommendation_Comments{get; set;}
    }

    public class Lopa_Comments_Children {
        public string Lopa_Comment { get; set;} 
    }

    public class Parking_Lot_Children {
        public string Parking_Lot_Issue { get; set; }
        public string Response	{get; set;}
        public string Responsible_Party	{get; set;}
        public string Start_Date	{get; set;}
        public string End_Date{get; set;}
    }

    public class Drawings_Children {
        public string Drawing { get; set; }
        public string Revision	{get; set;}
        public string Document_Type	{get; set;}
        public string Drawing_Description	{get; set;}
        public string Link	{get; set;}
    }
    public class Check_Lists_Children {
        public string Check_List_Description { get; set; }
        public string Check_List_Comments	{get; set;}
        public string Check_List_Questions	{get; set;}
        public Check_List_Questions_Children check_List_Questions_Children { get; set;}
    }

    public class Check_List_Questions_Children {
        public string Check_List_Question { get; set; }
        public string Check_List_Answer	{get; set;}
        public string Check_List_Justification	{get; set;}
        public string Check_List_Recommendation_IDs	{get; set;}
    }

    public class Check_List_Recommendations_Children
    {
        public string Check_List_Recommendation { get; set; }
        public string Check_List_Recommendation_Priority  {get; set;}
        public string Check_List_Recommendation_Responsible_Party	{get; set;}
        public string Check_List_Recommendation_Status	{get; set;}
        public string Check_List_Recommendation_Comments{get; set;}
    }
        

    public class Tab_Visibility
    {
        /*Tab_Visibility		{9}
NodesTab	:	true
DeviationsTab	:	true
PhaWorksheetsTab	:	true
LopaWorksheetsTab	:	true
CheckListsTab	:	true
RecommendationsTab	:	true
SafeguardsTab	:	true
ParkingLotTab	:	true
RiskCriteriaTab	:	true
*/
     
        public bool NodesTab { get; set;  }
        public bool DeviationsTab	{get; set; }
        public bool PhaWorksheetsTab	{get; set; }
        public bool LopaWorksheetsTab	{get; set; }
        public bool CheckListsTab	{get; set; }
        public bool RecommendationsTab	{get; set; }
        public bool SafeguardsTab	{get; set; }
        public bool ParkingLotTab	{get; set; }
        public bool RiskCriteriaTab	{get; set; }

    }

}
