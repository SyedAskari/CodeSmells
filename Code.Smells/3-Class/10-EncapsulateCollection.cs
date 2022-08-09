namespace Code.Smells.Class
{
    public class EncapsulateCollection {
    
    }

    public class Class
    {
        public string Name { get; set; }
    }

    public class Student_BadExample
    {
        public string Name { get; set; }
        public List<Class> Classes { get; set; }
    }

    public class RegistrationService_BadExample
    {
        public void RegisterStudent(Student_BadExample student, Class theClass)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (theClass == null) throw new ArgumentNullException(nameof(theClass));

            var currentClasses = student.Classes;
            // perform some logic to confirm the student can enroll in this class
            currentClasses.Add(theClass);
        }
    }
    
    public class Student_GoodExample
    {
        public string Name { get; set; }
        private readonly List<Class> _classes = new List<Class>();
        public IReadOnlyCollection<Class> Classes => _classes.AsReadOnly();

        public void EnrollIn(Class theClass)
        {
            if (theClass == null) throw new ArgumentNullException(nameof(theClass));
            // perform some logic to confirm the student can enroll in this class
            _classes.Add(theClass);
        }
    }

    public class RegistrationService_GoodExample
    {
        public void RegisterStudent(Student_GoodExample student, Class theClass)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (theClass == null) throw new ArgumentNullException(nameof(theClass));
            
            student.EnrollIn(theClass);
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Student_GoodExample> Students { get; set; }

        public override void OnModelCreating(ModelBuilder builder)
        {
            // locate the navigation of the property using nameof Student_GoodExample.Classes
            var navigation = builder.Metadata.FindNavigation(nameof(Student_GoodExample.Classes));
            // specify the property access mode, if we use the naming convention of naming your
            // backing field in a way that is consistent with the public property, in this
            // case the property name is capital Classes, the backing filed is _classes
            // that's the convention ef core expects, it will automatically use
            // that field to set the property of the collection when it retrieves this
            // entity from the database.
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }

    public class PropertyAccessMode
    {
        public static object Field { get; set; }
    }

    public class ModelBuilder
    {
        public Metadata Metadata { get; set; }
    }

    public class Metadata
    {
        public Navigation FindNavigation(string name)
        {
            throw new NotImplementedException();
        }
    }

    public class Navigation
    {
        public void SetPropertyAccessMode(object field)
        {
            throw new NotImplementedException();
        }
    }

    public class DbSet<T>
    {
    }

    public abstract class DbContext
    {
        public abstract void OnModelCreating(ModelBuilder builder);
    }
}