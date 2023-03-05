using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class Constants
{
    public const string Content_Type = "text/html";
    
    #region Bench
    public const string Response_Bench_Entry = "Bench entry has been created successfully.";
    public const string Response_Bench_Entry_Failed = "Bench entry has not been created.";
    public const string RE_EmpId_Not_Available_EA = "Employee not registered into EA Council";
    public const string RE_Remove_EA = "Employee entry deleted from EA Council";
    #endregion

    #region Certification
    public const string Response_Create_Certification = "Certification Details has been created.";
    public const string RT_EACouncil = "api/eacouncil";
    public const string Response_Remove_Certification = "Certification details deleted";
    #endregion

    #region Interview
    public const string Response_Add_Inetrview_Success = "New Interview details have been added Successfully";
    public const string Response_Add_Inetrview_Failure = "Failed to add New Interview details";
    #endregion


    #region API Routes
    public const string RT_Certification = "api/certification";

    #endregion
}
