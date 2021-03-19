# bootcamp_homework4
!!  Soru3 !!!

        --------Don't write to global functions-------------------------------------------
        //**Bad**//
        Array.prototype.diff = function diff(comparisonArray) {
         const hash = new Set(comparisonArray);
         return this.filter(elem => !hash.has(elem));
        //**Good**//
        class SuperArray extends Array {
        diff(comparisonArray) {
        const hash = new Set(comparisonArray);
       return this.filter(elem => !hash.has(elem));
        }
        //--------Use Ternary Operator----------------------------------------------
        //**Bad**//
        public string SomeMethod(int value){
         if(value == 10)
          {
          return "Value is 10";
          }
         else
         {
        return "Value is not 10";
        }}
        //**Good**//
         public string SomeMethod(int value)
         {
           return value == 10 ? "Value is 10" : "Value is not 10";
         }
        //-----Functions should do one thing---------------------------------
        //**bad**//
        function emailClients(clients)
        {
           clients.forEach(client => {
           const clientRecord = database.lookup(client);
           if (clientRecord.isActive())
           {
           email(client);
           }
           });
        }
        //**Good**//
        function emailActiveClients(clients) {
          clients.filter(isActiveClient).forEach(email);
          }
         function isActiveClient(client) {
         const clientRecord = database.lookup(client);
         return clientRecord.isActive(); }
        //---------Avoid negative conditionals---------------------------------------------------
        //**Bad**//
         function isDOMNodeNotPresent(node)
         {
             // ...
         }
         if (!isDOMNodeNotPresent(node)) {
         // ...
         }
        //**Good**//
         function isDOMNodePresent(node)
         {
             // ...
         }
         if (isDOMNodePresent(node)) {
         // ...
         }
        //-----Wrong Types---------------------------------------------------
        //**Bad**//
        public void Method()
        {
            int[] array1 = new int[5];
            int[] array2 = new int[6];
            int[] array3 = new int[7];
            int[] all = new int[array1.Length + array2.Length + array3.Length];
            array1.CopyTo(all, 0);
            array2.CopyTo(all, array1.Length);
            array3.CopyTo(all, array1.Length + array2.Length);
           }
        //**Good**//
         public void Method()
        {
         int[] array1 = new int[5];
         int[] array2 = new int[6];
         int[] array3 = new int[7];
         List<int>allElements =new List<int>();
         allElements.AddRange(array1);
         allElements.AddRange(array2);
         allElements.AddRange(array3);
         int[] all = allElements.ToArray();
        //------Encapsulate conditionals---------------------------------------------------
        //**Bad**//
        if (fsm.state === "fetching" && isEmpty(listNode)) {
         // ...
         }
        //**Good**//
        function shouldShowSpinner(fsm, listNode) {
         return fsm.state === "fetching" && isEmpty(listNode);
         }

         if (shouldShowSpinner(fsmInstance, listNodeInstance)) {
         // ...
         }
        //------Remove dead code----------------------------------------------
        //**Bad**//
         function oldRequestModule(url)
         {
             // ...
         }
         function newRequestModule(url)
         {
             // ...
         }
         const req = newRequestModule;
         inventoryTracker("apples", req, "BLABLABLA");
        //**Good**//
        function newRequestModule(url)
        {
            // ...
        }
        const req = newRequestModule;
        inventoryTracker("apples", req, "BLABLABLA");
        //---Single Responsibility Principle-----------------------------------
        //**Bad**//
        class UserSettings
        {
            constructor(user)
            {
            this.user = user;
            }

            changeSettings(settings)
            {
             if (this.verifyCredentials())
             {
              // ...
             } }
             verifyCredentials()
             {
              // ...
             } }
        //**Good**//
         class UserAuth
        {
        constructor(user)
        {
        this.user = user;
        }
        verifyCredentials()
       {
           // ...
       } }
       class UserSettings
       {
       constructor(user)
       {
        this.user = user;
        this.auth = new UserAuth(user);
       }
       changeSettings(settings)
       {
       if (this.auth.verifyCredentials())
       {
       // ...
        } } }
        //------Error Handling-Don't ignore caught errors---
        //**Bad**//
        try {
       functionThatMightThrow();
       } catch (error) {
        console.log(error); }
        //**Good**//
        try {
        functionThatMightThrow();
        } catch (error) {
       // One option (more noisy than console.log):
       console.error(error);
       // Another option:
       notifyUserOfError(error);
       // Another option:
        reportErrorToService(error);
       //OR do all three!
      }
       


       
