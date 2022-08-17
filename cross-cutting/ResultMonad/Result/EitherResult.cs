namespace ResultMonad;

// Either monad, It wil
// Bind - M<T>, T -> M<T1>
// 
public abstract class Either<TLeft,TRight>
{
    public abstract Either<TLeft,TRight1> Bind<TRight1>(Func<TRight,Either<TLeft,TRight1>> fn);

}

public class Right<TLeft,TRight> : Either<TLeft,TRight>
{
    TRight value;
    public  Right(TRight value)
    {
       this.value = value; 
    }

    public override Either<TLeft, TRight1> Bind<TRight1>(Func<TRight, Either<TLeft, TRight1>> fn)
    {
        return fn(this.value); 
    }
}

public class Left<TLeft,TRight> : Either<TLeft, TRight>
{
    TLeft value;

    public Left(TLeft value)
    {
        this.value = value;
    }

    public override Either<TLeft, TRight1> Bind<TRight1>(Func<TRight, Either<TLeft, TRight1>> fn)
    {
        return new Left<TLeft,TRight1>(this.value);
    }
}

