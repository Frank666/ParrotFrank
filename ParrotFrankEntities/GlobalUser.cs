using ParrotFrankEntities.parrot_frank;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParrotFrankEntities
{
    public static class GlobalUser
    {
        private static Users currentUser;

        public static Users CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
    }

}
