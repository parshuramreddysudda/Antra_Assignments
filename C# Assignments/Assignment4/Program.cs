//Practice working with Generics
    
 /*
 1. Create a custom Stack class MyStack<T> that can be used with any data type which
    has following methods
1. int Count()
2. T Pop()
3. Void Push()
*/

 using System.Runtime.Intrinsics.X86;

 class MyStack<T>
 {
     private int size = 0;
     public int limitSize = 10;
     public List<T> stack;
     
     public int Count()
     {
         return size;
         
     }
     
     public T Pop()
     {

         if (size == 0)
             throw new InvalidOperationException("Stack is Underflow");

         T var = stack.ElementAt(size);
         stack.RemoveAt(size--);
         return var;
     }

     public void Push(T val)
     {
         if (size == limitSize)
             throw new OverflowException("Stack is Overflow");
         
         if (size == 0)
             stack = new List<T>();
         else
            stack.Add(val);

         size++;

     }
 }
 
 
 
 /*2. Create a Generic List data structure MyList<T> that can store any data type.
     Implement the following methods.
 1. void Add (T element)
 2. T Remove (int index)
 3. bool Contains (T element)
 4. void Clear ()
 5. void InsertAt (T element, int index)
 6. void DeleteAt (int index)
 7. T Find (int index)
 */


 class MyList<T>
 {
     private List<T> items = new List<T>();

     public void Add(T element)
     {
         items.Add(element);
     }

     public T Remove(int index)
     {
         if (index < 0 || index >= items.Count)
         {
             throw new IndexOutOfRangeException("Index is out of range");
         }

         T removedItem = items[index];
         items.RemoveAt(index);
         return removedItem;
     }

     public bool Contains(T element)
     {
         return items.Contains(element);
     }

     public void Clear()
     {
         items.Clear();
     }

     public void InsertAt(T element, int index)
     {
         if (index < 0 || index > items.Count)
         {
             throw new IndexOutOfRangeException("Index is out of range");
         }

         items.Insert(index, element);
     }

     public void DeleteAt(int index)
     {
         if (index < 0 || index >= items.Count)
         {
             throw new IndexOutOfRangeException("Index is out of range");
         }

         items.RemoveAt(index);
     }

     public T Find(int index)
     {
         if (index < 0 || index >= items.Count)
         {
             throw new IndexOutOfRangeException("Index is out of range");
         }

         return items[index];
     }
 }

 /*User
     Implement a GenericRepository<T> class that implements IRepository<T> interface
     that will have common /CRUD/ operations so that it can work with any data source
 such as SQL Server, Oracle, In-Memory Data etc. Make sure you have a type constraint
     on T were it should be of reference type and can be of type Entity which has one
     property called Id. IRepository<T> should have following methods
 1. void Add(T item)
 2. void Remove(T item)
 Void Save()
 4. IEnumerable<T> GetAll()
 5. T GetById(int id)*/


// Define IRepository interface
 interface IRepository<T> where T : Entity
 {
     void Add(T item);
     void Remove(T item);
     void Save();
     IEnumerable<T> GetAll();
     T GetById(int id);
 }

 class Entity
 {
     public int Id { get; set; }
 }


 class GenericRepository<T> : IRepository<T> where T : Entity
 {
     private List<T> dataStore = new List<T>();

     public void Add(T item)
     {
         if (item == null)
         {
             throw new ArgumentNullException(nameof(item), "Item cannot be null");
         }

         if (dataStore.Any(e => e.Id == item.Id))
         {
             throw new InvalidOperationException($"Item with id {item.Id} already exists");
         }

         dataStore.Add(item);
     }

     public void Remove(T item)
     {
         if (item == null)
         {
             throw new ArgumentNullException(nameof(item), "Item cannot be null");
         }

         dataStore.Remove(item);
     }

     public void Save()
     {
         Console.WriteLine("Item saved successfully.");
     }

     public IEnumerable<T> GetAll()
     {
         return dataStore;
     }

     public T GetById(int id)
     {
         return dataStore.FirstOrDefault(e => e.Id == id);
     }
 }


 