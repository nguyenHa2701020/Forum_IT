namespace ForumIT.Models.Domain
{
    public class LuotBinhLuan
    {
        public int Id { get; set; }
        public int LuotBL { get; set; }
    }
}
/*-----------------data anotation----------
 * \: Dùng để escape (bỏ qua) các ký tự đặc biệt, để chúng được coi là ký tự thông thường.
Ví dụ, biểu thức chính quy /^0\d{8,11}$/ sẽ kiểm tra xem chuỗi có bắt đầu bằng số 0 và có từ 9 đến 12 chữ số.


Kết quả sẽ hiển thị "Phone number is valid." nếu số điện thoại thỏa mãn biểu thức chính quy và "Phone number is not valid." nếu không thỏa mãn.

Hy vọng rằng thông tin này sẽ giúp bạn hiểu cách sử dụng biểu thức chính quy trong C#.

giải thích thêm về biểu thức check mail

Biểu thức chính quy để kiểm tra tính hợp lệ của địa chỉ email ^\w+([-+.']\w+)@\w+([-.]\w+).\w+([-.]\w+)*$ có thể được giải thích như sau:

^: Bắt đầu của chuỗi.
\w+: Một hoặc nhiều ký tự chữ, số hoặc dấu gạch dưới.
([-+.']\w+): Một ký tự dấu gạch, dấu cộng, dấu trừ hoặc dấu chấm, theo sau bởi một hoặc nhiều ký tự chữ, số hoặc dấu gạch dưới.
@: Ký tự @.
\w+: Một hoặc nhiều ký tự chữ, số hoặc dấu gạch dưới.
([-.]\w+): Một ký tự dấu gạch hoặc dấu chấm, theo sau bởi một hoặc nhiều ký tự chữ, số hoặc dấu gạch dưới.
.: Ký tự dấu chấm.
\w+: Một hoặc nhiều ký tự chữ, số hoặc dấu gạch dưới.
([-.]\w+)*: Một ký tự dấu gạch hoặc dấu chấm, theo sau bởi một hoặc nhiều ký tự chữ, số hoặc dấu gạch dưới. Có thể có hoặc không xuất hiện, và có thể lặp lại nhiều lần.
$: Kết thúc của chuỗi.
------------------------------------------------------
 * Kiểm tra bắt buộc (Required): Đảm bảo rằng người dùng đã nhập giá trị cho trường thông tin. Bạn có thể sử dụng Data Annotation [Required] hoặc kiểm tra trong controller để đảm bảo rằng trường thông tin không được để trống.

Kiểm tra độ dài (Length): Kiểm tra độ dài của trường thông tin, chẳng hạn như số ký tự tối đa hoặc tối thiểu mà người dùng có thể nhập. Bạn có thể sử dụng Data Annotation [StringLength] để kiểm tra độ dài trong một khoảng xác định.

Kiểm tra định dạng (Format): Kiểm tra xem giá trị nhập vào có đúng định dạng hay không. Ví dụ, kiểm tra xem một trường email có đúng định dạng email hay không. Bạn có thể sử dụng Data Annotation [EmailAddress] để kiểm tra định dạng email.

Kiểm tra số (Numeric): Kiểm tra xem giá trị nhập vào có phải là một số hay không. Bạn có thể sử dụng Data Annotation [Range] để kiểm tra giá trị nằm trong một khoảng số cho trước.

Kiểm tra điều kiện tùy chỉnh: Đôi khi bạn có nhu cầu kiểm tra những điều kiện tùy chỉnh khác. Bạn có thể tạo các phương thức kiểm tra tùy chỉnh trong lớp ViewModel của bạn hoặc sử dụng Data Annotation [CustomValidation] để áp dụng các kiểm tra tùy chỉnh.
 */
/*--------------------Làm việc vs mảng 
 * 1. All: Xác định xem tất cả các phần tử của chuỗi có thỏa mãn một điều kiện hay không.
 * class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public static void AllEx()
{
    // Create an array of Pets.
    Pet[] pets = { new Pet { Name="Barley", Age=10 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=6 } };

    // Determine whether all pet names
    // in the array start with 'B'.
    bool allStartWithB = pets.All(pet =>
                                      pet.Name.StartsWith("B"));

    Console.WriteLine(
        "{0} pet names start with 'B'.",
        allStartWithB ? "All" : "Not all");
}

// This code produces the following output:
//
//  Not all pet names start with 'B'.
 * 
 * 
 * class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}
class Person
{
    public string LastName { get; set; }
    public Pet[] Pets { get; set; }
}

public static void AllEx2()
{
    List<Person> people = new List<Person>
        { new Person { LastName = "Haas",
                       Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
                                          new Pet { Name="Boots", Age=14 },
                                          new Pet { Name="Whiskers", Age=6 }}},
          new Person { LastName = "Fakhouri",
                       Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
          new Person { LastName = "Antebi",
                       Pets = new Pet[] { new Pet { Name = "Belle", Age = 8} }},
          new Person { LastName = "Philips",
                       Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
                                          new Pet { Name = "Rover", Age = 13}} }
        };

    // Determine which people have pets that are all older than 5.
    IEnumerable<string> names = from person in people
                                where person.Pets.All(pet => pet.Age > 5)
                                select person.LastName;

    foreach (string name in names)
    {
        Console.WriteLine(name);
    }

    /* This code produces the following output:
     *
     * Haas
     * Antebi
     *

 * 2. Any: Xác định xem có phần tử nào của chuỗi tồn tại hoặc thỏa mãn một điều kiện hay không.
 * class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}
class Person
{
    public string LastName { get; set; }
    public Pet[] Pets { get; set; }
}

public static void AnyEx2()
{
    List<Person> people = new List<Person>
        { new Person { LastName = "Haas",
                       Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
                                          new Pet { Name="Boots", Age=14 },
                                          new Pet { Name="Whiskers", Age=6 }}},
          new Person { LastName = "Fakhouri",
                       Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
          new Person { LastName = "Antebi",
                       Pets = new Pet[] { }},
          new Person { LastName = "Philips",
                       Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
                                          new Pet { Name = "Rover", Age = 13}} }
        };

    // Determine which people have a non-empty Pet array.
    IEnumerable<string> names = from person in people
                                where person.Pets.Any()
                                select person.LastName;

    foreach (string name in names)
    {
        Console.WriteLine(name);
    }

    /* This code produces the following output:

       Haas
       Fakhouri
       Philips
    *
    *class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Vaccinated { get; set; }
}

public static void AnyEx3()
{
    // Create an array of Pets.
    Pet[] pets =
        { new Pet { Name="Barley", Age=8, Vaccinated=true },
          new Pet { Name="Boots", Age=4, Vaccinated=false },
          new Pet { Name="Whiskers", Age=1, Vaccinated=false } };

    // Determine whether any pets over age 1 are also unvaccinated.
    bool unvaccinated =
        pets.Any(p => p.Age > 1 && p.Vaccinated == false);

    Console.WriteLine(
        "There {0} unvaccinated animals over age one.",
        unvaccinated ? "are" : "are not any");
}

// This code produces the following output:
//
//  There are unvaccinated animals over age one.
    
 * 
 * 
 * 3.Append  : Thêm một giá trị vào cuối chuỗi.
 * 
 * 
 * 4.AsEnumerable: Trả về đầu vào được nhập là IEnumerable<T> .
 * // Custom class.
class Clump<T> : List<T>
{
    // Custom implementation of Where().
    public IEnumerable<T> Where(Func<T, bool> predicate)
    {
        Console.WriteLine("In Clump's implementation of Where().");
        return Enumerable.Where(this, predicate);
    }
}

static void AsEnumerableEx1()
{
    // Create a new Clump<T> object.
    Clump<string> fruitClump =
        new Clump<string> { "apple", "passionfruit", "banana",
            "mango", "orange", "blueberry", "grape", "strawberry" };

    // First call to Where():
    // Call Clump's Where() method with a predicate.
    IEnumerable<string> query1 =
        fruitClump.Where(fruit => fruit.Contains("o"));

    Console.WriteLine("query1 has been created.\n");

    // Second call to Where():
    // First call AsEnumerable() to hide Clump's Where() method and thereby
    // force System.Linq.Enumerable's Where() method to be called.
    IEnumerable<string> query2 =
        fruitClump.AsEnumerable().Where(fruit => fruit.Contains("o"));

    // Display the output.
    Console.WriteLine("query2 has been created.");
}

// This code produces the following output:
//
// In Clump's implementation of Where().
// query1 has been created.
//
// query2 has been created.


 * 5. Average: Tính giá trị trung bình của một chuỗi các giá trị số.
 * List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

double average = grades.Average();

Console.WriteLine("The average grade is {0}.", average);

// This code produces the following output:
//
// The average grade is 77.6.

 * 6. Cast: Chuyển các phần tử của IEnumerable sang loại đã chỉ định.
 * System.Collections.ArrayList fruits = new System.Collections.ArrayList();
fruits.Add("mango");
fruits.Add("apple");
fruits.Add("lemon");

IEnumerable<string> query =
    fruits.Cast<string>().OrderBy(fruit => fruit).Select(fruit => fruit);

// The following code, without the cast, doesn't compile.
//IEnumerable<string> query1 =
//    fruits.OrderBy(fruit => fruit).Select(fruit => fruit);

foreach (string fruit in query)
{
    Console.WriteLine(fruit);
}

// This code produces the following output:
//
// apple
// lemon
// mango

from int i in objects

IEnumerable sequence = Enumerable.Range(0, 10);
var doubles = from int item in sequence
                select (double)item;

 * 7. Chunk: Chia các phần tử của một chuỗi thành các phần có kích thước tối đa size.
 * 
 * 8. Concat: Nối hai chuỗi.
 * class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

static Pet[] GetCats()
{
    Pet[] cats = { new Pet { Name="Barley", Age=8 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=1 } };
    return cats;
}

static Pet[] GetDogs()
{
    Pet[] dogs = { new Pet { Name="Bounder", Age=3 },
                   new Pet { Name="Snoopy", Age=14 },
                   new Pet { Name="Fido", Age=9 } };
    return dogs;
}

public static void ConcatEx1()
{
    Pet[] cats = GetCats();
    Pet[] dogs = GetDogs();

    IEnumerable<string> query =
        cats.Select(cat => cat.Name).Concat(dogs.Select(dog => dog.Name));

    foreach (string name in query)
    {
        Console.WriteLine(name);
    }
}

// This code produces the following output:
//
// Barley
// Boots
// Whiskers
// Bounder
// Snoopy
// Fido


 * 
 * 9.Contains: Xác định xem một chuỗi có chứa một phần tử được chỉ định hay không.

string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

string fruit = "mango";

bool hasMango = fruits.Contains(fruit);

Console.WriteLine(
    "The array {0} contain '{1}'.",
    hasMango ? "does" : "does not",
    fruit);

// This code produces the following output:
//
// The array does contain 'mango'.

10. Count: Trả về số phần tử trong một chuỗi.
string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

try
{
    int numberOfFruits = fruits.Count();
    Console.WriteLine(
        "There are {0} fruits in the collection.",
        numberOfFruits);
}
catch (OverflowException)
{
    Console.WriteLine("The count is too large to store as an Int32.");
    Console.WriteLine("Try using the LongCount() method instead.");
}

// This code produces the following output:
//
// There are 6 fruits in the collection.

11. DefaultIfEmpty: Trả về các phần tử của IEnumerable<T> hoặc bộ sưu tập đơn lẻ có giá trị mặc định nếu chuỗi trống.
class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public static void DefaultIfEmptyEx1()
{
    List<Pet> pets =
        new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 } };

    foreach (Pet pet in pets.DefaultIfEmpty())
    {
        Console.WriteLine(pet.Name);
    }
}

/*
 This code produces the following output:

 Barley
 Boots
 Whiskers
*
*List<int> numbers = new List<int>();

foreach (int number in numbers.DefaultIfEmpty())
{
    Console.WriteLine(number);
}

/*
 This code produces the following output:

 0
*
*
12:Distinct: Trả về các phần tử riêng biệt từ một chuỗi.
Product[] products = { new Product { Name = "apple", Code = 9 },
                       new Product { Name = "orange", Code = 4 },
                       new Product { Name = "apple", Code = 9 },
                       new Product { Name = "lemon", Code = 12 } };

// Exclude duplicates.

IEnumerable<Product> noduplicates =
    products.Distinct(new ProductComparer());

foreach (var product in noduplicates)
    Console.WriteLine(product.Name + " " + product.Code);

/*
    This code produces the following output:
    apple 9
    orange 4
    lemon 12
*


13.DistinctBy: 
14.ElementAt: Ví dụ mã sau đây minh họa cách sử dụng ElementAt để trả về một phần tử ở một vị trí cụ thể.
string[] names =
    { "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow",

        "Hedlund, Magnus", "Ito, Shu" };
Random random = new Random(DateTime.Now.Millisecond);

string name = names.ElementAt(random.Next(0, names.Length));

Console.WriteLine("The name chosen at random is '{0}'.", name);

/*
 This code produces output similar to the following:

 The name chosen at random is 'Ito, Shu'.
*

15.ElementAtOrDefault: 
string[] names =
    { "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow",
        "Hedlund, Magnus", "Ito, Shu" };

int index = 20;

string name = names.ElementAtOrDefault(index);

Console.WriteLine(
    "The name chosen at index {0} is '{1}'.",
    index,
    String.IsNullOrEmpty(name) ? "<no name at this index>" : name);

/*
 This code produces the following output:

 The name chosen at index 20 is '<no name at this index>'.
*
*

16.Empty: 
string[] names1 = { "Hartono, Tommy" };
string[] names2 = { "Adams, Terry", "Andersen, Henriette Thaulow",
                      "Hedlund, Magnus", "Ito, Shu" };
string[] names3 = { "Solanki, Ajay", "Hoeing, Helge",
                      "Andersen, Henriette Thaulow",
                      "Potra, Cristina", "Iallo, Lucio" };

List<string[]> namesList =
    new List<string[]> { names1, names2, names3 };

// Only include arrays that have four or more elements
IEnumerable<string> allNames =
    namesList.Aggregate(Enumerable.Empty<string>(),
    (current, next) => next.Length > 3 ? current.Union(next) : current);

foreach (string name in allNames)
{
    Console.WriteLine(name);
}

/*
 This code produces the following output:

 Adams, Terry
 Andersen, Henriette Thaulow
 Hedlund, Magnus
 Ito, Shu
 Solanki, Ajay
 Hoeing, Helge
 Potra, Cristina
 Iallo, Lucio
*
*

16.Except: Tạo ra sự khác biệt tập hợp của hai chuỗi.
ProductA[] fruits1 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "orange", Code = 4 },
                        new ProductA { Name = "lemon", Code = 12 } };

ProductA[] fruits2 = { new ProductA { Name = "apple", Code = 9 } };

// Get all the elements from the first array
// except for the elements from the second array.

IEnumerable<ProductA> except =
    fruits1.Except(fruits2);

foreach (var product in except)
    Console.WriteLine(product.Name + " " + product.Code);

/*
  This code produces the following output:

  orange 4
  lemon 12
*
*
17.ExceptBy: 

18First: Trả về phần tử đầu tiên của chuỗi.
int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54,
                    83, 23, 87, 435, 67, 12, 19 };

int first = numbers.First(number => number > 80);

Console.WriteLine(first);

/*
 This code produces the following output:

 92
*
*

18.FirstOrDefault: Trả về phần tử đầu tiên của chuỗi hoặc giá trị mặc định nếu không tìm thấy phần tử nào.
string[] names = { "Hartono, Tommy", "Adams, Terry",
                     "Andersen, Henriette Thaulow",
                     "Hedlund, Magnus", "Ito, Shu" };

string firstLongName = names.FirstOrDefault(name => name.Length > 20);

Console.WriteLine("The first long name is '{0}'.", firstLongName);

string firstVeryLongName = names.FirstOrDefault(name => name.Length > 30);

Console.WriteLine(
    "There is {0} name longer than 30 characters.",
    string.IsNullOrEmpty(firstVeryLongName) ? "not a" : "a");

/*
 This code produces the following output:

 The first long name is 'Andersen, Henriette Thaulow'.
 There is not a name longer than 30 characters.
*
*

20.GroupBy: Nhóm các phần tử của một chuỗi.
class Pet
{
    public string Name { get; set; }
    public double Age { get; set; }
}

public static void GroupByEx4()
{
    // Create a list of pets.
    List<Pet> petsList =
        new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                       new Pet { Name="Boots", Age=4.9 },
                       new Pet { Name="Whiskers", Age=1.5 },
                       new Pet { Name="Daisy", Age=4.3 } };

    // Group Pet.Age values by the Math.Floor of the age.
    // Then project an anonymous type from each group
    // that consists of the key, the count of the group's
    // elements, and the minimum and maximum age in the group.
    var query = petsList.GroupBy(
        pet => Math.Floor(pet.Age),
        pet => pet.Age,
        (baseAge, ages) => new
        {
            Key = baseAge,
            Count = ages.Count(),
            Min = ages.Min(),
            Max = ages.Max()
        });

    // Iterate over each anonymous type.
    foreach (var result in query)
    {
        Console.WriteLine("\nAge group: " + result.Key);
        Console.WriteLine("Number of pets in this age group: " + result.Count);
        Console.WriteLine("Minimum age: " + result.Min);
        Console.WriteLine("Maximum age: " + result.Max);
    }

    /*  This code produces the following output:

        Age group: 8
        Number of pets in this age group: 1
        Minimum age: 8.3
        Maximum age: 8.3

        Age group: 4
        Number of pets in this age group: 2
        Minimum age: 4.3
        Maximum age: 4.9

        Age group: 1
        Number of pets in this age group: 1
        Minimum age: 1.5
        Maximum age: 1.5
    *
    *
    *
21. GroupJoin: Tương quan các phần tử của hai chuỗi dựa trên đẳng thức khóa và nhóm các kết quả.
class Person
{
    public string Name { get; set; }
}

class Pet
{
    public string Name { get; set; }
    public Person Owner { get; set; }
}

public static void GroupJoinEx1()
{
    Person magnus = new Person { Name = "Hedlund, Magnus" };
    Person terry = new Person { Name = "Adams, Terry" };
    Person charlotte = new Person { Name = "Weiss, Charlotte" };

    Pet barley = new Pet { Name = "Barley", Owner = terry };
    Pet boots = new Pet { Name = "Boots", Owner = terry };
    Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
    Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

    List<Person> people = new List<Person> { magnus, terry, charlotte };
    List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

    // Create a list where each element is an anonymous
    // type that contains a person's name and
    // a collection of names of the pets they own.
    var query =
        people.GroupJoin(pets,
                         person => person,
                         pet => pet.Owner,
                         (person, petCollection) =>
                             new
                             {
                                 OwnerName = person.Name,
                                 Pets = petCollection.Select(pet => pet.Name)
                             });

    foreach (var obj in query)
    {
        // Output the owner's name.
        Console.WriteLine("{0}:", obj.OwnerName);
        // Output each of the owner's pet's names.
        foreach (string pet in obj.Pets)
        {
            Console.WriteLine("  {0}", pet);
        }
    }
}

/*
 This code produces the following output:

 Hedlund, Magnus:
   Daisy
 Adams, Terry:
   Barley
   Boots
 Weiss, Charlotte:
   Whiskers
*
*
22. Intersect: Tạo giao điểm cố định của hai chuỗi.
public class ProductA : IEquatable<ProductA>
{
    public string Name { get; set; }
    public int Code { get; set; }

    public bool Equals(ProductA other)
    {
        if (other is null)
            return false;

        return this.Name == other.Name && this.Code == other.Code;
    }

    public override bool Equals(object obj) => Equals(obj as ProductA);
    public override int GetHashCode() => (Name, Code).GetHashCode();
}
ProductA[] store1 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "orange", Code = 4 } };

ProductA[] store2 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "lemon", Code = 12 } };
// Get the products from the first array
// that have duplicates in the second array.

IEnumerable<ProductA> duplicates =
    store1.Intersect(store2);

foreach (var product in duplicates)
    Console.WriteLine(product.Name + " " + product.Code);

/*
    This code produces the following output:
    apple 9
*
IntersectBy
23. Join: Tương quan các phần tử của hai chuỗi dựa trên các khóa khớp.
class Person
{
    public string Name { get; set; }
}

class Pet
{
    public string Name { get; set; }
    public Person Owner { get; set; }
}

public static void JoinEx1()
{
    Person magnus = new Person { Name = "Hedlund, Magnus" };
    Person terry = new Person { Name = "Adams, Terry" };
    Person charlotte = new Person { Name = "Weiss, Charlotte" };

    Pet barley = new Pet { Name = "Barley", Owner = terry };
    Pet boots = new Pet { Name = "Boots", Owner = terry };
    Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
    Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

    List<Person> people = new List<Person> { magnus, terry, charlotte };
    List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

    // Create a list of Person-Pet pairs where
    // each element is an anonymous type that contains a
    // Pet's name and the name of the Person that owns the Pet.
    var query =
        people.Join(pets,
                    person => person,
                    pet => pet.Owner,
                    (person, pet) =>
                        new { OwnerName = person.Name, Pet = pet.Name });

    foreach (var obj in query)
    {
        Console.WriteLine(
            "{0} - {1}",
            obj.OwnerName,
            obj.Pet);
    }
}

/*
 This code produces the following output:

 Hedlund, Magnus - Daisy
 Adams, Terry - Barley
 Adams, Terry - Boots
 Weiss, Charlotte - Whiskers
*
*

Last: 
LastOrDefault:


25.LongCount: Trả về Int64 đại diện cho số phần tử trong một chuỗi.
class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public static void LongCountEx2()
{
    Pet[] pets = { new Pet { Name="Barley", Age=8 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=1 } };

    const int Age = 3;

    long count = pets.LongCount(pet => pet.Age > Age);

    Console.WriteLine("There are {0} animals over age {1}.", count, Age);
}

/*
 This code produces the following output:

 There are 2 animals over age 3.
*

26.Max: Trả về giá trị lớn nhất trong một chuỗi giá trị.

MaxBy
Min
MinBy
27. OfType: Lọc các phần tử của IEnumerable dựa trên loại được chỉ định.

28.Order: Sắp xếp các phần tử của dãy theo thứ tự tăng dần.

29.OrderBy: Sắp xếp các phần tử của chuỗi theo thứ tự tăng dần theo khóa.
class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public static void OrderByEx1()
{
    Pet[] pets = { new Pet { Name="Barley", Age=8 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=1 } };

    IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

    foreach (Pet pet in query)
    {
        Console.WriteLine("{0} - {1}", pet.Name, pet.Age);
    }
}

/*
 This code produces the following output:

 Whiskers - 1
 Boots - 4
 Barley - 8
*

29.OrderByDescending: Sắp xếp các phần tử của dãy theo thứ tự giảm dần.

OrderDescending
30.Prepend: Thêm một giá trị vào đầu chuỗi.

31.Range: Tạo ra một chuỗi các số nguyên trong một phạm vi được chỉ định.
// Generate a sequence of integers from 1 to 10
// and then select their squares.
IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

foreach (int num in squares)
{
    Console.WriteLine(num);
}

/*
 This code produces the following output:

 1
 4
 9
 16
 25
 36
 49
 64
 81
 100
*
*
31.Repeat:
Tạo một chuỗi chứa một giá trị lặp lại.
IEnumerable<string> strings =
    Enumerable.Repeat("I like programming.", 15);

foreach (String str in strings)
{
    Console.WriteLine(str);
}

/*
 This code produces the following output:

 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
 I like programming.
*
*
*
32.Reverse: Đảo ngược thứ tự của các phần tử trong một chuỗi.
char[] apple = { 'a', 'p', 'p', 'l', 'e' };

char[] reversed = apple.Reverse().ToArray();

foreach (char chr in reversed)
{
    Console.Write(chr + " ");
}
Console.WriteLine();

/*
 This code produces the following output:

 e l p p a
*
*
33.Select:  Chiếu từng phần tử của chuỗi thành một dạng mới.
string[] fruits = { "apple", "banana", "mango", "orange",
                      "passionfruit", "grape" };

var query =
    fruits.Select((fruit, index) =>
                      new { index, str = fruit.Substring(0, index) });

foreach (var obj in query)
{
    Console.WriteLine("{0}", obj);
}

/*
 This code produces the following output:

 {index=0, str=}
 {index=1, str=b}
 {index=2, str=ma}
 {index=3, str=ora}
 {index=4, str=pass}
 {index=5, str=grape}
*
*
34.SelectMany
class PetOwner
{
    public string Name { get; set; }
    public List<string> Pets { get; set; }
}

public static void SelectManyEx3()
{
    PetOwner[] petOwners =
        { new PetOwner { Name="Higa",
              Pets = new List<string>{ "Scruffy", "Sam" } },
          new PetOwner { Name="Ashkenazi",
              Pets = new List<string>{ "Walker", "Sugar" } },
          new PetOwner { Name="Price",
              Pets = new List<string>{ "Scratches", "Diesel" } },
          new PetOwner { Name="Hines",
              Pets = new List<string>{ "Dusty" } } };

    // Project the pet owner's name and the pet's name.
    var query =
        petOwners
        .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
        .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
        .Select(ownerAndPet =>
                new
                {
                    Owner = ownerAndPet.petOwner.Name,
                    Pet = ownerAndPet.petName
                }
        );

    // Print the results.
    foreach (var obj in query)
    {
        Console.WriteLine(obj);
    }
}

// This code produces the following output:
//
// {Owner=Higa, Pet=Scruffy}
// {Owner=Higa, Pet=Sam}
// {Owner=Ashkenazi, Pet=Sugar}
// {Owner=Price, Pet=Scratches}



35.SequenceEqual= ss2 chuôi

36.Single: Trả về một phần tử cụ thể của một chuỗi.
string[] fruits = { "apple", "banana", "mango",
                      "orange", "passionfruit", "grape" };

string fruit1 = fruits.Single(fruit => fruit.Length > 10);

Console.WriteLine(fruit1);

/*
 This code produces the following output:

 passionfruit
*
*
SingleOrDefault: Trả về một phần tử cụ thể của một chuỗi hoặc một giá trị mặc định nếu không tìm thấy phần tử đó.
string[] fruits2 = { };

string fruit2 = fruits2.SingleOrDefault();

Console.WriteLine(
    String.IsNullOrEmpty(fruit2) ? "No such string!" : fruit2);

/*
 This code produces the following output:

 No such string!
*
*
37.Skip: Bỏ qua một số phần tử được chỉ định trong một chuỗi và sau đó trả về các phần tử còn lại.
int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

Console.WriteLine("All grades except the first three:");
foreach (int grade in grades.Skip(3))
{
    Console.WriteLine(grade);
}

/*
 This code produces the following output:

All grades except the first three:
 56
 92
 98
 85
*
*
SkipLast
38.SkipWhile: Bỏ qua các phần tử trong một chuỗi miễn là điều kiện đã chỉ định là đúng và sau đó trả về các phần tử còn lại.
int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

IEnumerable<int> lowerGrades =
    grades
    .OrderByDescending(grade => grade)
    .SkipWhile(grade => grade >= 80);

Console.WriteLine("All grades below 80:");
foreach (int grade in lowerGrades)
{
    Console.WriteLine(grade);
}

/*
 This code produces the following output:

 All grades below 80:
 70
 59
 56
*
*
Sum
40.Take: Trả về số phần tử liền kề được chỉ định từ đầu một chuỗi.
int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

IEnumerable<int> topThreeGrades =
    grades.OrderByDescending(grade => grade).Take(3);

Console.WriteLine("The top three grades are:");
foreach (int grade in topThreeGrades)
{
    Console.WriteLine(grade);
}
/*
 This code produces the following output:

 The top three grades are:
 98
 92
 85
*
*
TakeLast
41.TakeWhile: Trả về các phần tử từ một chuỗi miễn là điều kiện đã chỉ định là đúng và sau đó bỏ qua các phần tử còn lại.
string[] fruits = { "apple", "passionfruit", "banana", "mango",
                      "orange", "blueberry", "grape", "strawberry" };

IEnumerable<string> query =
    fruits.TakeWhile((fruit, index) => fruit.Length >= index);

foreach (string fruit in query)
{
    Console.WriteLine(fruit);
}

/*
 This code produces the following output:

 apple
 passionfruit
 banana
 mango
 orange
 blueberry
*
*
42.ThenBy:Thực hiện sắp xếp tiếp theo các phần tử theo thứ tự tăng dần.
string[] fruits = { "grape", "passionfruit", "banana", "mango",
                      "orange", "raspberry", "apple", "blueberry" };

// Sort the strings first by their length and then
//alphabetically by passing the identity selector function.
IEnumerable<string> query =
    fruits.OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

foreach (string fruit in query)
{
    Console.WriteLine(fruit);
}

/*
    This code produces the following output:

    apple
    grape
    mango
    banana
    orange
    blueberry
    raspberry
    passionfruit
*
*
*
44. ThenByDescending: Thực hiện sắp xếp tiếp theo các phần tử theo thứ tự giảm dần.
public class CaseInsensitiveComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return string.Compare(x, y, true);
    }
}

public static void ThenByDescendingEx1()
{
    string[] fruits = { "apPLe", "baNanA", "apple", "APple", "orange", "BAnana", "ORANGE", "apPLE" };

    // Sort the strings first ascending by their length and
    // then descending using a custom case insensitive comparer.
    IEnumerable<string> query =
        fruits
        .OrderBy(fruit => fruit.Length)
        .ThenByDescending(fruit => fruit, new CaseInsensitiveComparer());

    foreach (string fruit in query)
    {
        Console.WriteLine(fruit);
    }
}

/*
    This code produces the following output:

    apPLe
    apple
    APple
    apPLE
    orange
    ORANGE
    baNanA
    BAnana
*
*
44. ToArray: Tạo một mảng từ IEnumerable<T>
class Package
{
    public string Company { get; set; }
    public double Weight { get; set; }
}

public static void ToArrayEx1()
{
    List<Package> packages =
        new List<Package>
            { new Package { Company = "Coho Vineyard", Weight = 25.2 },
              new Package { Company = "Lucerne Publishing", Weight = 18.7 },
              new Package { Company = "Wingtip Toys", Weight = 6.0 },
              new Package { Company = "Adventure Works", Weight = 33.8 } };

    string[] companies = packages.Select(pkg => pkg.Company).ToArray();

    foreach (string company in companies)
    {
        Console.WriteLine(company);
    }
}

/*
 This code produces the following output:

 Coho Vineyard
 Lucerne Publishing
 Wingtip Toys
 Adventure Works
*
*
ToDictionary
ToHashSet
45.ToList: string[] fruits = { "apple", "passionfruit", "banana", "mango",
                      "orange", "blueberry", "grape", "strawberry" };

List<int> lengths = fruits.Select(fruit => fruit.Length).ToList();

foreach (int length in lengths)
{
    Console.WriteLine(length);
}

/*
 This code produces the following output:

 5
 12
 6
 5
 6
 9
 5
 10
*
ToLookup
TryGetNonEnumeratedCount
Union: Tạo ra sự kết hợp tập hợp của hai chuỗi bằng cách sử dụng bộ so sánh đẳng thức mặc định.
public class ProductA : IEquatable<ProductA>
{
    public string Name { get; set; }
    public int Code { get; set; }

    public bool Equals(ProductA other)
    {
        if (other is null)
            return false;

        return this.Name == other.Name && this.Code == other.Code;
    }

    public override bool Equals(object obj) => Equals(obj as ProductA);
    public override int GetHashCode() => (Name, Code).GetHashCode();
}
ProductA[] store1 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "orange", Code = 4 } };

ProductA[] store2 = { new ProductA { Name = "apple", Code = 9 },
                       new ProductA { Name = "lemon", Code = 12 } };
//Get the products from the both arrays
//excluding duplicates.

IEnumerable<ProductA> union =
  store1.Union(store2);

foreach (var product in union)
    Console.WriteLine(product.Name + " " + product.Code);

/*
    This code produces the following output:

    apple 9
    orange 4
    lemon 12
*
*
UnionBy
50. Where: Lọc một chuỗi các giá trị dựa trên một vị từ.

Zip


//////////////////////////Gio Hang Session ////------------------------------
///Bây giờ, bạn có thể sử dụng session trong các controller và view. Dưới đây là một ví dụ về việc lưu trữ một mảng giá trị trong session:
csharp
Copy
public IActionResult Index()
{
    // Khởi tạo một mảng giá trị
    string[] myArray = { "Value 1", "Value 2", "Value 3" };

    // Lưu mảng giá trị vào session
    HttpContext.Session.SetObject("MyArray", myArray);

    return View();
}
Để truy xuất mảng giá trị từ session, bạn có thể sử dụng phương thức GetObject<T> như sau:
csharp
Copy
public IActionResult AnotherAction()
{
    // Truy xuất mảng giá trị từ session
    string[] myArray = HttpContext.Session.GetObject<string[]>("MyArray");

    // Sử dụng mảng giá trị
    // ...

    return View();
}
 * */