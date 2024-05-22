namespace OopLaba8.DataMaintenance
{
    public static class Validation
    {
        private static string allowedPhoneNumberCharacters = "0123456789";

        public static bool validatePhoneNumber(char[] phoneNumber) {
            if (phoneNumber.Length > 10) return false;
            foreach (var i in phoneNumber) {
                for (int j = 0; j < allowedPhoneNumberCharacters.Length; j++) {
                    if (i != allowedPhoneNumberCharacters[j]) ;
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool validateNumber(int number, int max, int min){
            return max>=number&&number>=min;
        }

    }
}