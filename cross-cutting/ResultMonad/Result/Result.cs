using System;
using System.Collections;
using System.Linq;

namespace ResultMonad
{
    public class Result
    {
        protected ErrorItem? Errors { get; set; }

        public Result(bool _hasErrors)
        {
            this._hasErrors = _hasErrors;

        }
        protected bool _hasErrors { get; set; }
        public Result()
        {
        }

        public Result(ErrorItem error)
        {
            this.Errors = error;
        }

        public bool HasErrors()
        {
            return (Errors != null);
        }
    }

    public class Result<T> : Result where T : class
    {
        T? tvalue = default(T);

        public Result(T value)
        {
            this.tvalue = value;
        }

        public Result(ErrorItem error): base(error)
        {

        }

        public Result(bool hasErrors)
        {
            this._hasErrors = hasErrors;
        }
        public Result<U> Bind<U>(Func<Result<U>> fn) where U : class
        {
            if (this.HasErrors())
                return new Result<U>(true);

            return fn();
        }
        public Result<U> Bind<U>(Func<T?,Result<U>> fn) where U : class
        {
            if (this.HasErrors())
                return new Result<U>(true);

            return fn(tvalue);
        }
    }
}