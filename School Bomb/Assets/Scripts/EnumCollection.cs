﻿using UnityEngine;
using System.Collections;

public enum DayOfWeek : short{
	All=0,Monday=1,Tuesday=2,Wedesday=3,Thursday=4,Friday=5,Saturday=6,Sunday=7
}

public enum TimeOfDay : short{
	All=0,Day=1,Evening=2,Night=3
}

public enum stageNum : short{
	SelectStage=0, Shop, Lab, ClubRoom, Lobbdy, Center, Dormitory, Corridor
}

public enum ItemPosition : short{
	toStore=0,toUser=1,alreadyUsed=2
}