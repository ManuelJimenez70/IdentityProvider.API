using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace IdentityProvaider.API
{
    public class DatetimeKindInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            ConvertLocalDatetimesToUtc(command.Parameters);

            return base.ReaderExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            ConvertLocalDatetimesToUtc(command.Parameters);

            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        private void ConvertLocalDatetimesToUtc(DbParameterCollection parameters)
        {
            foreach (DbParameter parameter in parameters)
            {
                if (parameter.Value is DateTime dateTime && dateTime.Kind == DateTimeKind.Local)
                {
                    parameter.Value = dateTime.ToUniversalTime();
                }
            }
        }
    }
}
