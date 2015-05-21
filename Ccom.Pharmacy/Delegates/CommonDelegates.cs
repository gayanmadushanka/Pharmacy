using System;

namespace Ccom.Pharmacy.Delegates
{
    //public delegate void GetSelectedPanaromaTile(PanaromaTileData panaromaTileData);

    //public delegate void GoBack();
    public delegate void FeedBack<in T>(T response);
    //public delegate void ToChangeVisualStateRequest(string visualStateName);
    //public delegate void StringPasser(string text);
    //public delegate bool ViewValidate();

    public delegate void ToChangeVisualStateRequest(string visualStateName);
    public delegate void ToSetManageViewRequest<in T>(T itemManageView);
    public delegate void ToManageEntityResponse(bool? isSuccess);

    public delegate void EditRequest<in T>(T selectedItem);

    public delegate void Result(Enum result);

}
