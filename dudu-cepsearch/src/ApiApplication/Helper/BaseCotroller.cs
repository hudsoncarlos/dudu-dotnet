using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiApplication.Helper
{
    public abstract class BaseCotroller : ControllerBase
    {
        protected IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
