# The Quest for the Universal Remote
Game 2 for Game Design - The Quest for the Universal Remote

# How to Setup Git
_**If you already have Git installed and setup with Github, skip to step 6**_
1. Download and install Git SCM from [here](https://git-scm.com).
2. Install Git LFS from [here](https://git-lfs.github.com).
3. Open up git bash and run the following command: <br/>
`ssh-keygen` <br/>
This will prompt you with a few questions. Answering the defaults is fine. You don't have to specify a password either.
This should generate two files, `id_rsa` and `id_rsa.pub`.
4. Now run the following command: <br/>
`cat ~/.ssh/id_rsa.pub` <br/>
This will print out your _public_ key. It should look like multiple lines of random gibberish; highlight it and copy it.<br/>
5. Now go to your [SSH settings page](https://github.com/settings/keys) on github and click `New SSH key`.<br/>
Come up with an elborate name (preferably the name of your computer) and paste your public key from earlier in the key field.
Click `Add SSH key`.<br/>
6. Now open up git bash again and `cd` to the folder you want to keep all your code. Run the following command: <br/>
`git clone git@github.com:krthornton/Game-2.git`<br/>
Congratulations! You have successfully "cloned" the repo.
7. Please see _How to Add the Project to Unity_ below.

# How to Add the Project to Unity
1. Follow the instructions from _How to Setup Git_ above.
2. Open up Unity Hub and click the `Add` button on the `Projects` tab
3. Navigate to the folder where you downloaded the repo and choose `Game-2`.<br/>
Unity should then open up with your project loaded. Reopening Unity should have the project saved in your recents.
5. You're now ready to go! Please see _How to Use Git in Unity_ below.

# How to Use Git in Unity
* Accessing Git in Unity
  1. Go to _Window > Github_. This should add the Github tab to your workspace (usually in the top right).
* Pulling
  * A `pull` downloads the most recent commits from the github repo. If you have un-committed changes,
  Git will fuss at you saying that you must commit your changes first. See _Committing_ down below.
  * How to Pull
    1. In the top right of Unity in the Github tab, click `Pull`<br/>
* Committing
  * Before committing, please make sure you're on the right branch! i.e. develop
  * A `commit` takes the changes you've selected and saves them to a 'commit' in your local copy of the repo.
  * In order for others to see your changes in your commit, you must first push your changes. See _Pushing_ down below.
  * How to Commit
    1. In the top right of Unity, click on the `Changes` tab
    2. Select the files you wish to commit (or optionally select `All` right above them)
    3. Below the list of files are two grey textboxes: `Commit Summary` and `Commit Description`. Fill them in appropriately
    describing your changes.
    4. Click `Commit to [branch]` to commit your changes
* Pushing
  * A 'push' officially submits any of the changes you've "committed" from your local copy of the repo to the repo on Github.
  * How to Push
    1. Click the `Push` button in the top right of Unity under the Github tab
* Changing Branches
  * A `branch` is essentially an alternate version of the repo. This allows us to keep at least one branch dedicated to
  versions of the code that we know work.
  * How to Switch branches
    1. Click on the `branches` tab under Github in the top right of Unity
    2. Double click on the desired branch and accept the dialog that comes up.
