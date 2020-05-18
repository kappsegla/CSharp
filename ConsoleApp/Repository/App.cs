namespace ConsoleApp.Repository
{
    public class App
    {
        public void Run()
        {
            IPersonRepository personRepository = new FilePersonRepository();

            var persons = personRepository.GetAll();
            
            


        }
        
        
        
    }
}