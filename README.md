# The Quest for the Universal Remote
Game 2 for Game Design - The Quest for the Universal Remote <br/>
Team Elidibus <br/>
Shelton Ellis <br/>
Kaleb Thornton <br/>
Denton Young <br/>
Brandon Birmingham <br/>

# Directory
- Screenshots are in `Screenshots`
- Gameplay Video is in `the video.zip`
- Final build of the exec (for Windows) is in `Builds.zip`

# Sources
- Unity 2D Game Kit [here](https://assetstore.unity.com/packages/essentials/tutorial-projects/2d-game-kit-107098)
- Brackey's 2D Character Controller [here](https://github.com/Brackeys/2D-Character-Controller)
- Caverns Environment by Luis Zuno [here](http://pixelgameart.org/web/portfolio/caverns-environment/)
- Towel Defence Soundtrack by sawsquarenoise [here](https://freemusicarchive.org/music/sawsquarenoise/Towel_Defence_OST)

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
5. You're now ready to go!
