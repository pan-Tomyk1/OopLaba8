namespace OopLaba8.Users
{
    public class RegularUserProfile : UserProfile
    {
        public RegularUserProfile(string name, string surname, string email, string phoneNumber) 
            :base(name, surname, email, phoneNumber){ 
        }

        public RegularUserProfile() 
            :base(){
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}