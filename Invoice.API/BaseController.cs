using System.Text.Json.Nodes;
using Invoice.API.Contract;
using Invoice.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API;

public class BaseController : Controller
{
    private readonly APIEvent _apiEvent;

    public BaseController(APIEvent apiEvent)
    {
        _apiEvent = apiEvent;
    }

    protected virtual async JsonResult DoAsync<T>(Func<Task<T>> doFunc)
    {
        var method = HttpContext.Request.Method;

        try
        {
            var result = await doFunc();
            CommonResponseBase<T> response = new CommonResponseBase<T>
            {
                RequestId = _apiEvent.EventID,
                ResponseCode = ResponseCode.Success,
                Data = result
            }; 
            return Json(response);
        }
        catch(BusinessException ex)
        {
            return GenerateErrorResponse(ex);
        }
        catch(Exception ex)
        {
            return GenerateErrorResponse();
        }
    }

    protected virtual ObjectResult Do<T>(Func<T> doFunc)
    {
        return DoAsync<T>(async () => {return await Task.FromResult(doFunc());}
            ).GetAwaiter().GetResult();
    }


    private JsonObject GenerateErrorResponse()
    {
        List<BusinessError> errors = new List<BusinessError>();
        foreach(ModelStateEntry item in ModelState.Values)
        {
            foreach(ModelError error in item.Errors)
            {
                errors.Add(new BusinessError(error.ErrorMessage));
            }
        }
        BusinessException businessException = new BusinessException(errors);
        return GenerateErrorResponse(businessException);
    }

    private JsonObject GenerateErrorResponse(BusinessException ex)
        {
            CommonResponseBase<List<ErrorResponse>> errorResponse = new CommonResponseBase<List<ErrorResponse>>()
            {
                RequestId = _apiEvent.EventID,
                ResponseCode = ResponseCode.BusinssError
            };

            List<ErrorResponse> errors = new List<ErrorResponse>();
            foreach (BusinessError error in ex.Errors)
            {
                errors.Add(new ErrorResponse() { ErrorCode = error.Code, ErrorDescription = error.Details, ErrorMessage = error.Message });
            }

            errorResponse.Data = errors;
            return Json(errorResponse);
        }
}
