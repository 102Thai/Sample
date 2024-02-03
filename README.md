delegate:
-khái niệm: delegate là kiểu dữ liệu tham chiếu. được sử dụng để lấy tham chiếu đến 1 hoặc nhiều hàm. nó được sử dụng để gọi 1 hoặc nhiều hàm một cách linh hoạt.
- ta có thể sử dụng muticast để gán nhiều hàm cho 1 biến kiểu delegate.
- các kiểu delegate có sẵn trong C#:
+ Func<T,T,...Tn> là 1 delagate có kiểu trả về(int,float,...) trong đó T thứ i là kiểu của parameter, T thứ n là kiểu trả về của Func. Func có thể có nhiều parameter.
ví dụ:
static Main(){
Funct<int,int,int> add= (int a,int b)=> a+b;
}
hoặc:
static int Add(int a, int b){
return a+b;
}
static Main(){
Funct<int,int,int> add=Add;
add(5,6)

+ Action<T,T,...Tn> là 1 delegate không có kiểu trả về. T thứ i đến T thứ n là kiểu của parameter.
ví dụ:
static void Write(string something){
console.WriteLine(something);
}
static void Main(){
Action<string> Print= Write;
Write("Hello");
}

+Predicate<T> là 1 delegate có kiểu trả về là bool. có duy nhất 1 T là kiểu của parameter.
ví dụ:
static bool IsEven(int a){
return a%2==0;
}
static void Main(){
Predicate isEven= IsEven;
console.writeline(isEven(6));
}
hoặc 
static Main(){
Predicate<int> isEven = a => a % 2 == 0;
Console.WriteLine(isEven(6));
}

-delegate có thể được sử dụng như 1 parameter của 1 hàm.
ví dụ:
 static void Message()
 {
     Console.WriteLine("Did something");
 }

 static void DoSomething(Action action)
 {
     Console.WriteLine("Do some thing");
     action();
 }
static void Main(string[] args)
{
    DoSomething(Message);}
________________________________________
event C#: 
-Khái niệm: event là 1 từ khóa trong C#. có tác dụng thông báo thông báo cho các class khác(các class đăng ký thực thi delegate) biết rằng có 1 sự kiện nào đó đang xảy ra.
- từ khóa event được sử dụng để khai báo 1 sự kiện. nó đứng ngay sau phạm vi truy cập và đứng trước kiểu delegate. ví dụ: public event OnJump onJump;
- lớp kích hoạt sự kiện được gọi là lớp publisher, các lớp phản ứng khi sự kiện xả ra gọi là subscribers. khi pulisher kích hoạt sự kiện thì các lớp subscribers sẽ phản ứng với sự kiện.
- lợi ích của việc sử dụng event:
+giúp gửi thông báo về sự kiện từ 1 class nào đó để thực hiện các hàm đăng ký sự.
+giúp dễ dàng mở rộng, bảo trì mã nguồn.
+ giảm sự phụ thuộc cứng giữa các class. việc sử dụng mô hình event có thể giúp giảm sự phụ thuộc trực tiếp giữa các class
ví dụ:

public class EventArgsData: EventArgs
{
    public string name;
    public EventArgsData(string name) {
        this.name = name;
    }
}

//publisher
public class Customer
{
    public event EventHandler OnAddProduct;
    public string customerName;
    public void Buy()
    {
        Console.Write("Enter your name: ");
        customerName = Console.ReadLine();
        OnAddProduct?.Invoke(this, new EventArgsData(customerName));
    }
}

//subcriber
public class Vegatable
{
    public string vegatableType;
    public Vegatable(Customer customer)
    {
        customer.OnAddProduct += AddtoCart;
    }

    public void AddtoCart(object sender, EventArgs e)
    {
        EventArgsData eventArgsData=(EventArgsData)e;
        Console.WriteLine($"{eventArgsData.name} bought {vegatableType} sucessly");
    }
}

public class Meat
{
    public string meatType;
    public Meat(Customer customer)
    {
        customer.OnAddProduct += AddtoCart;
    }
    
    public void AddtoCart(object sender, EventArgs e)
    {
        EventArgsData eventArgsData = (EventArgsData)e;
        Console.WriteLine($"{eventArgsDatatrình
internal class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer();
        Vegatable vegatable = new Vegatable(customer);
        Meat meat = new Meat(customer);
        vegatable.vegatableType = "beans";
        meat.meatType = "Beef";
        customer.Buy();
    }
}

____________________________________________
unityEvent:
- khái niệm: unityEvent là 1 cơ chế cho phép 1 lớp gửi thông báo cho các lớp khác(các lớp đăng ký sự kiện) biết rằng có 1 sự kiện từ lớp gửi thông báo đang diễn ra.
- được unity tạo ra. được bổ sung thêm 1 số tính năng so với event thôn thường của C#.
- về cơ bản thì unityEvent và event C# đều có cách hoạt động tương đồng nhau.
- ví dụ:
//publisher
using unityEngine;
using unityEngine.eventSystem;
public class Customer: MonoBehaviour
{
    public static unityEvent<string> OnAddProduct;
    public string customerName;
    public void Buy()
    {
        Console.Write("Enter your name: ");
        customerName = Console.ReadLine();
        OnAddProduct?.Invoke(customerName);
    }
}

//subcriber
public class Vegatable: MonoBehaviour
{
    public string vegatableType;
    void Start(){
       Customer.OnAddProduct.AddListener(AddToCart);
    }
    
    public void AddToCart(string customerName)
    {
        string customerName= customerName;
        Console.WriteLine($"{customerName} bought {vegatableType} sucessly");
    }
}

public class Meat
{
     public string meatType;
    void Start()
    {
       Customer.OnAddProduct.AddListener(AddToCart);
    }
    
    public void AddToCart(string customerName)
    {
        string customerName= customerName;
        Console.WriteLine($"{customerName} bought {meatType} sucessly");
    }
}

______________________________________________
-Observer Pattern
- khái niệm: Observer pattern là 1 một nhiều mẫu thiết kế được sử dụng để giải quyết vấn đề xác định. vấn đề xác định ở đây có thể là khi class này thay đổi 1 trạng thái nào đó và nó muốn thông báo cho những class khác(class lắng nghe) biết đến sự thay đổi này mà không cần biết đến sự tồn tại của các class lắng nghe. điều này giúp tách biệt các class, giảm sự phụ thuộc và dễ mở rộng chương trình.
- có nhiều cách để triển khi mô hình Observer pattern. 
+cách 1 là sử dụng event: khi triển khai cách này thì có thể nói "triển khai event cũng chính là triển khai mô hình Observer pattern">
+cách 2 là không sử dụng event( sử dụng gọi callback). // tại sao lại là gọi callback? nhờ đại ca giải thích.

ví dụ về cách k sử dụng event:

public interface IObserver
{
    void OnPlayerLevelUp(int level);
}

// Lớp đối tượng quan sát (Observer)
public class EnemyAI : MonoBehaviour, IObserver
{
    public void OnPlayerLevelUp(int level)
    {
        Debug.Log($"EnemyAI: Detected player's level change - New player's level: {level}");
        // Thực hiện logic xử lý khác...
    }
}

public class PlayerInfo: IObserver
{
    [SerializeField] Text playerLevelText;
    
    public void OnPlayerLevelUp(int level)
    {
        playerLevelText.text= level.toString();
    }
}

// Lớp đối tượng có thể quan sát (Subject)
public class Player : MonoBehaviour
{
    int exp, currentLevel;
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Attack()
    {
        if(!input.getkey(keycode.F) return;
        exp++;
        if(exp<=1000) return;
        exp=0;
        Levelup();
    
    // Gọi callback cho tất cả các Observers
    private void LevelUp()
    {
        currentLevel++;
        foreach (var observer in observers)
        {
            observer.OnPlayerLevelUp(currentLevelcurrentLevel);
        }
    }

    void Update()
    {
        Attack();
    }
}

// Sử dụng
public class GameManager : MonoBehaviour
{
    private Player player;
    private EnemyAI enemyAI;

    private void Start()
    {
        // Đăng ký đối tượng quan sát (Observer)
        character.AddObserver(enemyAI);
    }
}










