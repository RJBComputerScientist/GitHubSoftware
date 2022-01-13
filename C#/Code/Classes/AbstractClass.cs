abstract class BaseClass{
    protected int _x = 200;
    protected int _y = 300;

	public          abstract    void        AbstractMethod();
//  ^accessModifier ^modifier   ^returnType ^methodName(   ^parameters)

    public abstract int X {get;}
    public abstract int Y {get;}

    class DerivedClass : BaseClass {
        public override void AbstractMethod(){
            _x++;
            _y++;
        }
        public override int x {
            get{
                return _x + 20;
            }

        }
        public override int y{
            get{
                return _y + 20;
            }

        }

    } 
}
