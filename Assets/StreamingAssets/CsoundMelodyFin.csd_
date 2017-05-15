

;newer not working
<Cabbage>
form caption("CsoundMelody2"),
hslider channel("relativeHeightSlider"), text("Relative Height"), range(0, 9, 0)
;hslider channe2("absoluteHeightSlider"), text("Absolute Hight"),
;range(0, 9, 0)
hslider channel2("wheelSlider"), text("Wheel Proximity"),
range(0, 1, 0)
hslider channel3("AfterDemoSlider"), text("After Demo"),
range(0, 1, 0)
hslider channel4("PlatformSlider"), text("Platform Proximity"),
range(0, 1, 0)
hslider channel5("CristmasLightsSlider"), text("Christmas Lights Proximity"),
range(0, 1, 0)
hslider channel6("PinballSlider"), text("Pinball Proximity"),
range(0, 1, 0)

hslider channe7("SkateboardSlider"), text("Skateboard Proximity"),
range(0, 1, 0)range(0, 1, 0)
hslider channe7("EndSlider"), text("End Proximity"),
range(0, 1, 0)

</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -m0d
</CsOptions>
<CsInstruments>
sr 	= 	88200 
ksmps 	= 	32
nchnls 	= 	2
0dbfs	=	1 



gkHiHat = 0
giEvl0 init 0.00
gkEnv init 0 
gkWheel init 0 
gkNotWheel init 0.05
gkPitch0 = 0.0
gkPitch2 = 2
gkKickVol = 0
gkBBall init 0 
gkKickVol2 init 0 
gkChristmass init 0

instr 6; snare
  icps0  = 147
  iamp   = p4*i(gkKickVol)

  icps1  =  2.0 * icps0
  
  kcps   port icps0, 0.007, icps1
  kcpsx  =  kcps * 1.5
  
  kfmd   port   0.0, 0.01, 0.7
  aenv1  expon  1.0, 0.03, 0.5
  kenv2  port   1.0, 0.008, 0.0
  aenv2  interp kenv2
  aenv3  expon  1.0, 0.025, 0.5
  
  a_     oscili 1.0, kcps, 1
  a1     oscili 1.0, kcps * (1.0 + a_*kfmd), 1
  a_     oscili 1.0, kcpsx, 1
  a2     oscili 1.0, kcpsx * (1.0 + a_*kfmd), 1
  
  a3     unirand 2.0
  a3     =  a3 - 1.0
  a3     butterbp a3, 5000, 7500
  a3     =  a3 * aenv2
  
  a0     =  a1 + a2*aenv3 + a3*1.0
  a0     =  a0 * aenv1

  outs a0*iamp, a0*iamp
endin


instr 10; snare
  icps0  = 147
  iamp   = p4*(i(gkKickVol2)*2)

  icps1  =  2.0 * icps0
  
  kcps   port icps0, 0.007, icps1
  kcpsx  =  kcps * 1.5
  
  kfmd   port   0.0, 0.01, 0.7
  aenv1  expon  1.0, 0.03, 0.5
  kenv2  port   1.0, 0.008, 0.0
  aenv2  interp kenv2
  aenv3  expon  1.0, 0.025, 0.5
  
  a_     oscili 1.0, kcps, 1
  a1     oscili 1.0, kcps * (1.0 + a_*kfmd), 1
  a_     oscili 1.0, kcpsx, 1
  a2     oscili 1.0, kcpsx * (1.0 + a_*kfmd), 1
  
  a3     unirand 2.0
  a3     =  a3 - 1.0
  a3     butterbp a3, 5000, 7500
  a3     =  a3 * aenv2
  
  a0     =  a1 + a2*aenv3 + a3*1.0
  a0     =  a0 * aenv1

  outs a0*iamp, a0*iamp
endin








instr PLAYER_MOVE
      krnd randh 1, 10, 10 
	kHeight  chnget "relativeHeightSlider"
 ;printks "gkPitch (%d)  kheight: %d\n", 0.25, gkPitch0, kHeight
      if kHeight<=0.5 then		;-15 
         gkPitch0 = 0			
      elseif  kHeight >0.5 && kHeight<=1 then		;-13 
         gkPitch0 = 7			
      elseif kHeight >1 && kHeight<=1.5 then    ;-11
	    gkPitch0 = 12
      elseif kHeight >1.5 then    ;-9
	    gkPitch0 = 24
 	endif
      ;printks "gkPitch (%d) \n", 0.25, gkPitch0
      

      iAbsHeight chnget "absoluteHeightSlider"
     if iAbsHeight>-11 then		;-15
         gkEnv = 1
     elseif  iAbsHeight <-11  then
          gkEnv = 0
     endif   
     
 
 
     iNearWheel chnget "wheelSlider"
     if      iNearWheel= 0 && krnd < 0 then		;-15 
         gkWheel = 0	
         gkNotWheel = 0.05		
      elseif   iNearWheel >0 && krnd >= 0 then    
         gkWheel = 0.08	
         gkNotWheel = 0
     	endif 
     iNearPinball chnget "PinballSlider"
     if      iNearPinball= 0 && krnd < -0.5 then		;-15 
         gkWheel = 0	
         gkNotWheel = 0.05		
      elseif   iNearPinball >0 && krnd >= -0.5 then    
         gkWheel = 0.08	
         gkNotWheel = 0
     	endif  	
 	
	
 	
 	
 
 	iPlatform chnget "PlatformSlider"
 	if iPlatform= 0 then		;-15 
         gkPlatform	= 0	
      elseif  iPlatform >0 then     
         gkPlatform = 0.09
 	endif  	
     iChristmassLights chnget "CristmasLightsSlider";
     if  iChristmassLights= 0 then		;-15 iChristmassLights= 0 &&
         gkChristmass = 0	
         	
          printks "0- KRANDOM %f CHRISTMAS %f\n", 0.1, krnd, gkChristmass

      elseif  iChristmassLights >0 &&  krnd < 0 then   ;iChristmassLights >0 &&


         gkChristmass = 0.05
         gkNotWheel = 0
                printks "0+ KRANDOM %f CHRISTMAS %f\n", 0.1, krnd, gkChristmass
      elseif  iChristmassLights >0 &&  krnd >= 0 then   ;iChristmassLights >0 &&


         gkChristmass = 0
         gkNotWheel = 0.05
                printks "0+ KRANDOM %f CHRISTMAS %f\n", 0.1, krnd, gkChristmass          
     	endif 
      iSkateboard chnget "SkateboardSlider";
      if iSkateboard= 0 then		;-15 
         gkHiHat = 0
         gkKickVol2	= 0	
         ;gkKickVol = 0.40
         ;gkNotWheel = 0.05		
      elseif   iSkateboard >0 && krnd < 0 then    
         gkHiHat = 0.005
         gkKickVol2 = 0.2	
         ;gkNotWheel = 0
         gkKickVol = 0
      elseif   iSkateboard >0 && krnd >= 0 then    
         gkHiHat = 0
         gkKickVol2	= 0.2	
         ;gkKickVol = 0.40
         ;gkNotWheel = 0.05	
         gkKickVol = 0        
 	endif  	
       iAfterDemo  chnget "AfterDemoSlider"
 	if iAfterDemo= 0 then		;-15 
         gkKickVol	= 0
      elseif  iAfterDemo >0 && iSkateboard= 0 then     
         gkKickVol = 0.40
 	endif 
 	iEnd  chnget "EndSlider"
 	if iEnd > 0 then
 	  gkKickVol	= 0
 	  gkKickVol2 =0
 	  
 	 endif 
 	;iBBall = 0;chnget "BasketballSlider"
 	;if iBBall= 0 || krnd > 0 then		;-15 
       ;  gkBBall	= 0
         ;gkNotWheel = 0.1	
     ;elseif  iBBall >0 && krnd <= 0 then     
      ;   gkBBall = 0.05
       ;  gkNotWheel = 0
 	;endif   	
 
 
 
 
 	;iBBallKicks = 0;chnget "BasketballSlider"
 	;if iBBallKicks= 0 then		;-15 
       ; gkKickVol2	= 0	
      ;elseif  iBBallKicks >0 then     
       ; gkKickVol2 = 0.2
 	;endif   	
 	     
     
endin




instr 20

  ilen = i(gkHiHat);init p3
  ilen = 5;init p3
  iamp = 0.5;init p4

  kcutfreq  expon     10000, 0.01, 2500
  aamp      expon     iamp,  0.02,   i(gkHiHat)
  arand     rand      aamp
  alp1      butterlp  arand,kcutfreq
  alp2      butterlp  alp1,kcutfreq
  ahp1      butterhp  alp2,3500
  asigpre   butterhp  ahp1,3500
  asig      linen    (asigpre+arand/20),0.01,ilen, 0.5  

  out asig, asig
endin









instr 1 				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     i(gkWheel) , p3, 0;i(gkWheel)        ; amplitude envelope
	a1 	oscil 	aEnv, cpspch(p5 + ((gkPitch0)/100) -1 ), 4 	; audio oscillator
	out 	a1, a1 		; send signal to channel 1
endin

instr 2 				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     i(gkNotWheel), p3, 0;i(gkEnv);giEvl0
      ;aEnv adsr p3*.3, p3*.1, .4, p3*.1 ;         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5 + ((gkPitch0)/100) -1), 2 	; audio oscillator
	out 	asig, asig 		; send signal to channel 1

endin
instr 5 				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     0.2, p3, 0;i(gkEnv);giEvl0
      ;aEnv adsr p3*.3, p3*.1, .4, p3*.1 ;         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5  ), 5 	; audio oscillator
	out 	asig, asig 		; send signal to channel 1

endin


instr 7 ;platform				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     i(gkPlatform), p3, 0;i(gkPlatform);i(gkPlatform);giEvl0
      ;aEnv adsr p3*.3, p3*.1, .4, p3*.1 ;         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5  ), 13 	; audio oscillator
	out 	asig, asig 		; send signal to channel 1

endin
instr 8 ;platform				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     i(gkBBall), p3, 0;i(gkBBall);i(gkPlatform);i(gkPlatform);giEvl0
      ;aEnv adsr p3*.3, p3*.1, .4, p3*.1 ;         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5  ), 5 	; audio oscillator
	out 	asig, asig 		; send signal to channel 1

endin

instr 11 ;christmass				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     i(gkChristmass), p3, 0;i(gkChristmass);i(gkPlatform);i(gkPlatform);giEvl0
      ;aEnv adsr p3*.3, p3*.1, .4, p3*.1 ;         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5  ), 14 	; audio oscillator
	out 	asig, asig 		; send signal to channel 1

endin


instr 4
  iamp      = p4

  k1  expon     120, .2, 50    
  k2  expon     500, .4, 200
  a1  oscil     iamp, k1, 1 
  a2  reson     a1, k2, 50
  a3  butterlp  a2+a1,k1,1
  a4  butterlp  a3,   k1,1
  a5  butterlp  a4,2500,1
  a6  butterhp  a5,50
  a7  butterhp  a6,50
  a8  linen     a7,0.01,p3, .2  
  
  out a8
endin


instr 3; kick
k1  expon    p4, .2, 30
aenv expon i(gkKickVol), p3, 0.0001;i(gkKickVol)
a1  poscil    1, k1, 3
outs a1*aenv, a1*aenv
endin 


instr 9; kick
k1  expon    p4, .2, 30
aenv expon i(gkKickVol2), p3, 0.0001
a1  poscil    1, k1, 6
outs a1*aenv, a1*aenv
endin 





</CsInstruments>
<CsScore>
f1 0 65536 10 1

;f1 	0 	256 	10 	1 	;  a sine wave function table


;f3 0 1024 5 0.1 20  1 100 0.001 	;  a sine wave function table
 ;f4 0 1024 9 1 1  1 10   1 	;  a sine wave function table
 ;f5 0 1024 9 01 5 1 500 0.001 	;  a sine wave function table
;f6 0 1024 5 0.1 20 1 100 0.001 	;  a sine wave function table
f7 0 1024 5 0.1 20 1 100 0.001 	;  a sine wave function table


 f2 0 1024 9 0.8 100 1 100 0.001 	;  a sine wave function table
 f4 0 16384 10 1 0   0.1 0    0.5 0     0.14 0     .111   ;sq circus
 f5 0 1024 10 1 1 10 10 0.001 	;  frantic sine
 f13 0 1024 9 1 1 1 1 0.1 	;  frantic sine
 f14 0 1024 6 1 100 100 100 0.001 	;  frantic sine 
 f3 0 1024 10 1;kick
 f6 0 1024 10 1; kick fast 
;f1 0 16384 10 1 0   0.3 0    0.2 0     0.14 0     .111   ;sq

;f2 0 16384 10 1 0   0.3 0    0.2 0     0.14 0     .111   ;sq
;f3 0 16384 10 1 0   0.3 0    0.2 0     0.14 0     .111   ;sq
;f4 0 16384 10 1 0   0.1 0    0.5 0     0.14 0     .111   ;sq circus
;f5 0 16384 10 1 0   0.3 0    0.2 0     0.14 0     .111   ;sq
;f6 0 16384 10 1 0   0.3 0    0.2 0     0.14 0     .111   ;sq

;f2 0 16384 10 1 1   1   1    0.7 0.5   0.3  0.1
;f3 0 16384 10 1 1   1   1    0.7 0.5   0.3  0.1
;f5 0 16384 10 1 1   1   1    0.7 0.5   0.3  0.1
;f6 0 16384 10 1 1   1   1    0.7 0.5   0.3  0.1
;f7 0 16384 10 1 1   1   1    0.7 0.5   0.3  0.1

;f2 2 0 3 -2 1 0 -1
;f3 2 0 3 -2 1 0 -1
;f4 2 0 3 -2 1 0 -1
;f5 2 0 3 -2 1 0 -1
;f6 2 0 3 -2 1 0 -1

;f3 0 1024 5 0.1 20 1 100 0.001 
;f4 0 1024 5 0.1 20 1 100 0.001
;f4  0 16384 10 1
;f5 0 1024 5 0.1 20 1 100 0.001
;f7 0 1024 5 0.1 20 1 100 0.001
 

;f6 0 1024 10 1 

;i"PLAYER_MOVE" 0 [3600*12]
r 200 CNT








i20   0         0.1        0.2
i20   0.125         0.1        0.2
i20   0.25      0.05        0.2
i20   0.375         0.1        0.2
i20   0.5       0.1        0.2
i20   0.625       0.03        0.06
i20   0.75         0.1        0.2

i20   1      0.05        0.2

i20   1.25       0.1        0.2
i20   1.5      0.05        0.2
i20   1.625         0.05        0.06
i20   1.75         0.1        0.2

i20   2.125         0.1        0.2
i20   2.25      0.05        0.2
i20   2.375         0.1        0.2
i20   2.5       0.1        0.2
i20   2.625       0.03        0.06
i20   2.75         0.1        0.2
i20   2.875         0.1        0.2

i20   3      0.05        0.2

i20   3.25       0.1        0.2
i20   3.5      0.05        0.2
i20   3.625         0.05        0.06
i20   3.75         0.1        0.2
i20   3.875         0.1        0.2


i20   4         0.1        0.2
i20   4.125         0.1        0.2
i20   4.25      0.05        0.2
i20   4.375         0.1        0.2
i20   4.5       0.1        0.2
i20   4.625       0.03        0.06
i20   4.75         0.1        0.2

i20   5      0.05        0.2

i20   5.25       0.1        0.2
i20   5.5      0.05        0.2
i20   5.625         0.05        0.06
i20   5.75         0.1        0.2

i20   6.125         0.1        0.2
i20   6.25      0.05        0.2
i20   6.375         0.1        0.2
i20   6.5       0.1        0.2
i20   6.625       0.03        0.06
i20   6.75         0.1        0.2
i20   6.875         0.1        0.2

i20   7      0.05        0.2

i20   7.25       0.1        0.2
i20   7.5      0.05        0.2
i20   7.625         0.05        0.06
i20   7.75         0.1        0.2
i20   7.875         0.1        0.2




;i 1 0  5 1


;i4 0  1    0.02 	1 

i"PLAYER_MOVE" 0 0.25
i"PLAYER_MOVE" 0.25 0.25
i"PLAYER_MOVE" 0.5 0.25
i"PLAYER_MOVE" 0.75 0.25
i"PLAYER_MOVE" 1 0.25
i"PLAYER_MOVE" 1.25 0.25
i"PLAYER_MOVE" 1.5 0.25
i"PLAYER_MOVE" 1.75 0.25
i"PLAYER_MOVE" 2 0.25
i"PLAYER_MOVE" 2.25 0.25
i"PLAYER_MOVE" 2.5 0.25
i"PLAYER_MOVE" 2.75 0.25
i"PLAYER_MOVE" 3 0.25
i"PLAYER_MOVE" 3.25 0.25
i"PLAYER_MOVE" 3.5 0.25
i"PLAYER_MOVE" 3.75 0.25
i"PLAYER_MOVE" 4 0.25
i"PLAYER_MOVE" 4.25 0.25
i"PLAYER_MOVE" 4.5 0.25
i"PLAYER_MOVE" 4.75 0.25
i"PLAYER_MOVE" 5 0.25
i"PLAYER_MOVE" 5.25 0.25
i"PLAYER_MOVE" 5.5 0.25
i"PLAYER_MOVE" 5.75 0.25
i"PLAYER_MOVE" 6 0.25
i"PLAYER_MOVE" 6.25 0.25
i"PLAYER_MOVE" 6.5 0.25
i"PLAYER_MOVE" 6.75 0.25
i"PLAYER_MOVE" 7 0.25
i"PLAYER_MOVE" 7.25 0.25
i"PLAYER_MOVE" 7.5 0.25
i"PLAYER_MOVE" 7.75 0.25

 
i31 0




i11  0          0.2   0 	8.10
i11  0.5         .    0 	8.10
i11  1           .    0 	8.10
i11  2           .    0 	8.10
i11  2.5         .    0 	8.10
i11  3           .    0 	8.10
i11  4           .    0 	8.10
i11  4.5         .    0 	8.13
i11  5           .    0 	8.06
i11  5.75       0.2   0 	8.08
i11  6          0.2   0 	8.10
i11  6.5          0.2   0 	8.10
i11  7          0.2   0 	8.10
i11  7.5          0.2   0 	8.10



i11  [0+0.25]          0.2   0 	8.08
i11  [0.5+0.25]        .    0 	8.08
i11  [1+0.25]         .    0 	8.08
i11  [2+0.25]        .    0 	8.08
i11  [2.5+0.25]        .    0 	8.08
i11  [3+0.25]         .    0 	8.08
i11  [4+0.25 ]       .    0 	8.08
i11  [4.5+0.25]        .    0 	8.11
i11  [5+0.25]        .    0 	8.03
i11  [5.75+0.25]      0.2   0 	8.06
i11  [6+0.25]        0.2   0 	8.08
i11  [6.5+0.25]        0.2   0 	8.08
i11  [7+0.25]        0.2   0 	8.08
i11  [7.5+0.25]        0.2   0 	8.08 
;basketball melody
i8  0           0.1    0 	8.10
;i8  0.0625      .    0 	8.08
i8  0.125       .     0 	8.06
;i8  0.1875      .    0 	8.03
i8  0.25        .     0 	8.01
;i8  0.3125      .     0 	8.10
i8  0.375       .     0 	8.08
;i8  0.4375      .     0 	8.06
i8  0.5         .     0 	8.12
;i8  0.5625      .     0 	8.13
i8  0.625       .     0 	8.10
;i8  0.6875      .     0 	8.12
i8  0.75        .     0 	8.13
;i8  0.8125      .     0 	8.15
i8  0.875       .     0 	8.13
;i8  0.9375      .     0 	8.12

i8  1           .     0 	8.13
;i8  1.0625      .     0 	8.12
i8  1.125       .     0 	8.10
;i8  1.1875      .     0 	8.13
i8  1.25        .     0 	8.12
;i8  1.3125      .     0 	8.10
i8  1.375       .     0 	8.08
;i8  1.4375      .     0 	8.06
i8  1.5         .     0 	8.12
;i8  1.5625      0.05    0 	8.13
i8  1.625       .     0 	8.10
;i8  1.6875      0.02    0 	8.12
i8  1.75        .     0 	8.13
;i8  1.8125      0.05    0 	8.15
i8  1.875       .     0 	8.13
;i8  1.9375      0.02    0 	8.12

i8  2           .     0 	8.10
;i8  2.0625      0.05    0 	8.08
i8  2.125       .     0 	8.06
;i8  2.1875      0.05    0 	8.03
i8  2.25        .     0 	8.01
;i8  2.3125      0.05    0 	8.10
i8  2.375       .     0 	8.08
;i8  2.4375      0.05    0 	8.06
i8  2.5         .     0 	8.12
;i8  2.5625      0.05    0 	8.13
i8  2.625       .     0 	8.10
;i8  2.6875      0.05    0 	8.12
i8  2.75        .     0 	8.13
;i8  2.8125      0.05    0 	8.15
i8  2.875       .     0 	8.13
;i8  2.9375      0.05    0 	8.12

i8  3           .     0 	8.13
;i8  3.0625      0.05    0 	8.12
i8  3.125       .     0 	8.10
;i8  3.1875      0.05    0 	8.13
i8  3.25        .     0 	8.12
;i8  3.3125      0.05    0 	8.10
i8  3.375       .     0 	8.08
;i8  3.4375      0.05    0 	8.06
i8  3.5         .     0 	8.12
;i8  3.5625      0.05    0 	8.13
i8  3.625       .     0 	8.10
;i8  3.6875      0.05    0 	8.12
i8  3.75        .     0 	8.13
;i8  3.8125      0.05    0 	8.15
i8  3.875       .     0 	8.13
;i8  3.9375      0.05    0 	8.12

i8  4           .     0 	8.10
;i8  4.0625      0.05    0 	8.08
i8  4.125       .     0 	8.06
;i8  4.1875      0.05    0 	8.03
i8  4.25        .     0 	8.01
;i8  4.3125      0.05    0 	8.10
i8  4.375       .     0 	8.08
;i8  4.4375      0.05    0 	8.06
i8  4.5         .     0 	8.12
;i8  4.5625      0.05    0 	8.13
i8  4.625       .     0 	8.10
;i8  4.6875      0.05    0 	8.12
i8  4.75        .     0 	8.13
;i8  4.8125      0.05    0 	8.15
i8  4.875       .     0 	8.13
;i8  4.9375      0.05    0 	8.12

i8  5           .    0 	8.13
;i8  5.0625      0.05    0 	8.12
i8  5.125       .     0 	8.10
;i8  5.1875      0.05    0 	8.13
i8  5.25        .     0 	8.12
;i8  5.3125      0.05    0 	8.10
i8  5.375       .     0 	8.08
;i8  5.4375      0.05    0 	8.06
i8  5.5         .    0 	8.12
;i8  5.5625      0.05    0 	8.13
i8  5.625       .     0 	8.10
;i8  5.6875      0.05    0 	8.12
i8  5.75        .     0 	8.13
;i8  5.8125      0.05    0 	8.15
i8  5.875       .     0 	8.13
;i8  5.9375      0.05    0 	8.1

i8  6           .     0 	8.10
;i8  6.0625      0.05    0 	8.08
i8  6.125       .     0 	8.06
;i8  6.1875      0.05    0 	8.03
i8  6.25        .     0 	8.01
;i8  6.3125      0.05    0 	8.10
i8  6.375       .     0 	8.08
;i8  6.4375      0.05    0 	8.06
i8  6.5         .     0 	8.12
;i8  6.5625      0.05    0 	8.13
i8  6.625       .     0 	8.10
;i8  6.6875      0.05    0 	8.12
i8  6.75        .     0 	8.13
;i8  6.8125      0.05    0 	8.15
i8  6.875       .     0 	8.13
;i8  6.9375      0.05    0 	8.12

i8  7           .     0 	8.13
;i8  7.0625      0.05    0 	8.12
i8  7.125       .     0 	8.10
;i8  7.1875      0.05    0 	8.13
i8  7.25        .     0 	8.12
;i8  7.3125      0.05    0 	8.10
i8  7.375       .     0 	8.08
;i8  7.4375      0.05    0 	8.06
i8  7.5         .     0 	8.12
;i8  7.5625      0.05    0 	8.13
i8  7.625       .     0 	8.10
;i8  7.6875      0.05    0 	8.12
i8  7.75        .     0 	8.13
;i8  7.8125      0.05    0 	8.15
i8  7.875       .     0 	8.13
;i8  7.9375      0.05    0 	8.12











;platform melody
i7  0      0.12    0 	8.01
i7  0.125  0.12    0 	8.03
i7  0.25   0.12    0 	8.06
i7  0.375  0.12    0 	8.01
i7  0.5    0.12    0 	8.01
i7  0.625  0.12    0 	8.03

i7  0.75   0.12    0 	8.08
i7  0.875   0.12    0 	8.03


i7  1      0.12    0 	8.01
i7  1.125  0.12    0 	8.03
i7  1.25   0.12    0 	8.06
i7  1.375  0.12    0 	8.01
i7  1.5    0.12    0 	8.01
i7  1.625  0.12    0 	8.03
i7  1.75   0.12    0 	8.08
i7  1.875   0.12    0 	8.03

i7  2      0.12    0 	8.01
i7  2.125  0.12    0 	8.03
i7  2.25   0.12    0 	8.06
i7  2.375  0.12    0 	8.01
i7  2.5    0.12    0 	8.01
i7  2.625  0.12    0 	8.03
i7  2.75   0.12    0 	8.08
i7  2.875   0.12    0 	8.03


i7  3      0.12    0 	8.01
i7  3.125  0.12    0 	8.03
i7  3.25   0.12    0 	8.06
i7  3.375  0.12    0 	8.01
i7  3.5    0.12    0 	8.01
i7  3.625  0.12    0 	8.03
i7  3.75   0.12    0 	8.08
i7  3.875   0.12    0 	8.03

i7  4      0.12    0 	8.01
i7  4.125  0.12    0 	8.03
i7  4.25   0.12    0 	8.06
i7  4.375  0.12    0 	8.01
i7  4.5    0.12    0 	8.01
i7  4.625  0.12    0 	8.03
i7  4.75   0.12    0 	8.08
i7  4.875   0.12    0 	8.03


i7  5      0.12    0 	8.01
i7  5.125  0.12    0 	8.03
i7  5.25   0.12    0 	8.06
i7  5.375  0.12    0 	8.01
i7  5.5    0.12    0 	8.01
i7  5.625  0.12    0 	8.03
i7  5.75   0.12    0 	8.08
i7  5.875   0.12    0 	8.03

i7  6      0.12    0 	8.01
i7  6.125  0.12    0 	8.03
i7  6.25   0.12    0 	8.06
i7  6.375  0.12    0 	8.01
i7  6.5    0.12    0 	8.01
i7  6.625  0.12    0 	8.03
i7  6.75   0.12    0 	8.08
i7  6.875   0.12    0 	8.03


i7  7      0.12    0 	8.01
i7  7.125  0.12    0 	8.03
i7  7.25   0.12    0 	8.06
i7  7.375  0.12    0 	8.01
i7  7.5    0.12    0 	8.01
i7  7.625  0.12    0 	8.03
i7  7.75   0.12    0 	8.08
i7  7.875   0.12    0 	8.03




;i"PLAYER_MOVE2" 0 8


i6 1      0.25 0.2
i6 3      0.25 0.2
i6 5      0.25 0.2
i6 7      0.25 0.2

;kicks
i3 0         0.5  100 
i3 0.75      0.5  100 
i3 2.75      0.5  100 
;i3 3.00      0.5  100 
i3 4         0.5  100 
i3 4.75      0.5  100 
i3 6.00      0.5  100 
i3 6.75      0.5  100 
i3 7.25      0.5  100
i3 7.50      0.5  100
i3 7.75      0.25 100




i9 0         0.5  100
i9 0.125         0.5  100 
i9 0.25         0.5  100
i10 0.5      0.25 0.2
i9 0.725         0.5  100
i9 1.125         0.5  100
i10 1.5      0.25 0.2

;i9 2         0.5  100
;i9 2.125         0.5  100 
i9 2.25         0.5  100
i9 2.375         0.5  100
i10 2.5      0.25 0.2
i9 2.725         0.5  100
i9 3.125         0.5  100
i10 3.5      0.25 0.2




i9 4         0.5  100
i9 4.125         0.5  100 
i9 4.25         0.5  100
i10 4.5      0.25 0.2
i9 4.725         0.5  100
i9 5.125         0.5  100
i10 5.5      0.25 0.2

i9 6         0.5  100
i9 6.125         0.5  100 
i9 6.25         0.5  100
i10 6.5      0.25 0.2
i9 6.725         0.5  100
i9 7.125         0.5  100
i10 7.5      0.25 0.2



;wheel 1
;i1  0  0.25    0 	8.10
;i1  0.5  0.25    0 	8.09
;i1  1  0.20    0 	8.08
;i1  1.25  0.20    0 	8.09
;i1  1.5  0.20    0 	8.08
;i1  1.75  0.2    0 	8.07
;i1  2  0.25    0 	8.06
;i1  2.5  0.25    0 	8.05
;i1  3  0.25    0 	8.04
;i1  3.5  0.25    0 	8.05

;i1  4  0.25    0 	8.06
;i1  4.5  0.25    0 	8.05
;i1  5  0.20    0 	8.04
;i1  5.25  0.20    0 	8.05
;i1  5.5  0.20    0 	8.04
;i1  5.75  0.2    0 	8.03
;i1  6  0.25    0 	8.02
;i1  6.5  0.25    0 	8.01
;i1  7  0.25    0 	8.00
;i1  7.5  0.25    0 	8.01





;wheel 2
i1  0  0.25    0 	8.13
i1  0  0.25    0 	8.20
i1  0.5  0.25    0 	8.10
i1  0.5  0.25    0 	8.18
i1  1  0.20    0 	8.08
i1  1.25  0.20    0 	8.10
i1  1.5  0.20    0 	8.08
i1  1.75  0.2    0 	8.06
i1  2  0.25    0 	8.03
i1  2.5  0.25    0 	8.01
i1  3  0.25    0 	8.00
i1  3.5  0.25    0 	8.01
i1  4  0.25    0 	8.03
i1  4.5  0.25    0 	8.06
i1  5  0.20    0 	8.01
i1  5.25  0.20    0 	8.03
i1  5.5  0.20    0 	8.06
i1  5.75  0.2    0 	8.03
i1  6  0.25    0 	8.01
i1  6.5  0.25    0 	8.00
i1  7  0.25    0 	7.08 
i1  7.5  0.25    0 	8.06 








;-------------------main melody---------------------
i5  [0.00 + 0.0 * $CNT.]  1    0 	6.06 
i5  [4.00 + 0.0 * $CNT.]  1    0 	6.03
i5  [6.00 + 0.0 * $CNT.]  1    0 	6.01

;i5  [0.00 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
;i5  [0.25 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
;i5  [0.50 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
;i5  [0.75 + 0.0 * $CNT.]  .25    0        [7.06 - 0]

 
;i1  [4.00 + 0.0 * $CNT.]  1.25    0 	7.03
;i1  [6.00 + 0.0 * $CNT.]  1.25    0 	7.01



;i2  [0.00 + 0.0 * $CNT.]  1    0 	6.03
;i2  [4.00 + 0.0 * $CNT.]  1    0 	6.08
;i2  [6.00 + 0.0 * $CNT.]  1    0 	6.10


i2  [0.00 + 0.0 * $CNT.]  .25    0 	8.06  
i2  [0.50 + 0.0 * $CNT.]   . 	. 	8.08 
i2  [1.00 + 0.0 * $CNT.]   . 	. 	8.03
i2  [1.50 + 0.0 * $CNT.]   . 	. 	8.01
i2  [2.00 + 0.0 * $CNT.]   . 	. 	8.03 
;i2  [2.25 + 0.0 * $CNT.]   . 	. 	8.10
i2  [2.40 + 0.0 * $CNT.]   . 	. 	8.01
i2  [2.75 + 0.0 * $CNT.]   . 	. 	8.01
;i2  [3.25 + 0.0 * $CNT.]   . 	. 	8.06
i2  [3.50 + 0.0 * $CNT.]   . 	. 	8.01
i2  [3.75 + 0.0 * $CNT.]   . 	. 	8.01

i2  [4.00 + 0.0 * $CNT.]  .     	.    7.08
i2  [4.50 + 0.0 * $CNT.]   . 	. 	7.10 
i2  [5.00 + 0.0 * $CNT.]   . 	. 	7.15
i2  [5.50 + 0.0 * $CNT.]   . 	. 	8.01
i2  [6.00 + 0.0 * $CNT.]   . 	. 	8.03 
;i2  [6.25 + 0.0 * $CNT.]   . 	. 	8.10
i2  [6.4 + 0.0 * $CNT.]   . 	. 	8.01
i2  [6.75 + 0.0 * $CNT.]   . 	. 	8.01
i2  [7.25 + 0.0 * $CNT.]   . 	. 	8.06
;i2  [7.50 + 0.0 * $CNT.]   . 	. 	8.01
i2  [7.75 + 0.0 * $CNT.]   .25 	. 	8.06




;i2  [0.00 + 0.0 * $CNT.]  .25    0 	8.10  
i2  [0.50 + 0.0 * $CNT.]   . 	. 	8.10 
i2  [1.00 + 0.0 * $CNT.]   . 	. 	8.08
i2  [1.50 + 0.0 * $CNT.]   . 	. 	8.08
i2  [2.00 + 0.0 * $CNT.]   . 	. 	8.06 
i2  [2.40 + 0.0 * $CNT.]   . 	. 	8.06
;i2  [2.50 + 0.0 * $CNT.]   . 	. 	8.01
i2  [2.75 + 0.0 * $CNT.]   . 	. 	8.03
;i2  [3.25 + 0.0 * $CNT.]   . 	. 	8.06
i2  [3.50 + 0.0 * $CNT.]   . 	. 	8.06
i2  [3.75 + 0.0 * $CNT.]   . 	. 	8.06

i2  [4.00 + 0.0 * $CNT.]  .     	.    7.13
i2  [4.50 + 0.0 * $CNT.]   . 	. 	7.15 
i2  [5.00 + 0.0 * $CNT.]   . 	. 	7.18
i2  [5.50 + 0.0 * $CNT.]   . 	. 	7.15
i2  [6.00 + 0.0 * $CNT.]   . 	. 	7.18 
;i2  [6.25 + 0.0 * $CNT.]   . 	. 	8.10
i2  [6.40 + 0.0 * $CNT.]   . 	. 	7.15
i2  [6.75 + 0.0 * $CNT.]   . 	. 	7.15
i2  [7.25 + 0.0 * $CNT.]   . 	. 	8.08
;i2  [7.50 + 0.0 * $CNT.]   . 	. 	8.01
i2  [7.75 + 0.0 * $CNT.]   .25 	. 	8.08





s




</CsScore>
</CsoundSynthesizer>




r 8 CNT
i2  [0.00 + 0.0 * $CNT.]  .25    0 	8.06  
i2  [0.50 + 0.0 * $CNT.]   . 	. 	8.08 
i2  [1.00 + 0.0 * $CNT.]   . 	. 	8.03
i2  [1.50 + 0.0 * $CNT.]   . 	. 	8.01
i2  [2.00 + 0.0 * $CNT.]   . 	. 	8.13 
i2  [2.25 + 0.0 * $CNT.]   . 	. 	8.10
i2  [2.50 + 0.0 * $CNT.]   . 	. 	8.08
i2  [2.75 + 0.0 * $CNT.]   . 	. 	8.06
i2  [3.25 + 0.0 * $CNT.]   . 	. 	8.06
i2  [3.50 + 0.0 * $CNT.]   . 	. 	8.06
i2  [3.75 + 0.0 * $CNT.]   . 	. 	8.06


i1  [0.00 + 0.0 * $CNT.]   .25    0 	7.01 
i1  [0.25 + 0.0 * $CNT.]    .    . 	6.06;;;;;;;
i1  [0.50 + 0.0 * $CNT.]    .    . 	7.03
i1  [1.00 + 0.0 * $CNT.]    .    . 	7.06
i1  [1.50 + 0.0 * $CNT.]    .    .     7.08 
i1  [2.00 + 0.0 * $CNT.]    .    .     7.10
i1  [2.25 + 0.0 * $CNT.]    .    .     7.08
i1  [2.50 + 0.0 * $CNT.]    .    .     7.06
i1  [2.75 + 0.0 * $CNT.]    .    .     7.10
i1  [3.25 + 0.0 * $CNT.]    .    .     7.06
i1  [3.50 + 0.0 * $CNT.]    .    .     6.15
i1  [3.75 + 0.0 * $CNT.]    .    .     6.18
s















;basketball melody
i8  0           0.05    0 	8.10
;i8  0.0625      0.05    0 	8.08
;i8  0.125       0.05    0 	8.06
;i8  0.1875      0.05    0 	8.03
i8  0.25        0.05    0 	8.01
;i8  0.3125      0.05    0 	8.10
i8  0.375       0.05    0 	8.08
;i8  0.4375      0.05    0 	8.06
i8  0.5         0.05    0 	8.12
;i8  0.5625      0.05    0 	8.13
i8  0.625       0.05    0 	8.10
;i8  0.6875      0.05    0 	8.12
i8  0.75        0.05    0 	8.13
;i8  0.8125      0.05    0 	8.15
i8  0.875       0.05    0 	8.13
i8  0.9375      0.05    0 	8.12

;i8  1           0.02    0 	8.13
;i8  1.0625      0.02    0 	8.12
i8  1.125       0.02    0 	8.10
i8  1.1875      0.02    0 	8.13
;i8  1.25        0.02    0 	8.12
i8  1.3125      0.02    0 	8.10
;i8  1.375       0.02    0 	8.08
;i8  1.4375      0.02    0 	8.06
i8  1.5         0.02    0 	8.12
i8  1.5625      0.02    0 	8.13
i8  1.625       0.02    0 	8.10
;i8  1.6875      0.02    0 	8.12
i8  1.75        0.02    0 	8.13
;i8  1.8125      0.02    0 	8.15
i8  1.875       0.02    0 	8.13
;i8  1.9375      0.02    0 	8.12

i8  2           0.05    0 	8.10
;i8  2.0625      0.05    0 	8.08
i8  2.125       0.05    0 	8.06
;i8  2.1875      0.05    0 	8.03
i8  2.25        0.05    0 	8.01
;i8  2.3125      0.05    0 	8.10
i8  2.375       0.05    0 	8.08
;i8  2.4375      0.05    0 	8.06
i8  2.5         0.05    0 	8.12
;i8  2.5625      0.05    0 	8.13
i8  2.625       0.05    0 	8.10
;i8  2.6875      0.05    0 	8.12
i8  2.75        0.05    0 	8.13
i8  2.8125      0.05    0 	8.15
i8  2.875       0.05    0 	8.13
i8  2.9375      0.05    0 	8.12

;i8  3           0.02    0 	8.13
;i8  3.0625      0.02    0 	8.12
i8  3.125       0.02    0 	8.10
i8  3.1875      0.02    0 	8.13
i8  3.25        0.02    0 	8.12
;i8  3.3125      0.02    0 	8.10
i8  3.375       0.02    0 	8.08
;i8  3.4375      0.02    0 	8.06
i8  3.5         0.02    0 	8.12
i8  3.5625      0.02    0 	8.13
;i8  3.625       0.02    0 	8.10
;i8  3.6875      0.02    0 	8.12
i8  3.75        0.02    0 	8.13
i8  3.8125      0.02    0 	8.15
;i8  3.875       0.02    0 	8.13
i8  3.9375      0.02    0 	8.12

i8  4           0.05    0 	8.10
i8  4.0625      0.05    0 	8.08
i8  4.125       0.05    0 	8.06
i8  4.1875      0.05    0 	8.03
i8  4.25        0.05    0 	8.01
i8  4.3125      0.05    0 	8.10
i8  4.375       0.05    0 	8.08
i8  4.4375      0.05    0 	8.06
;i8  4.5         0.05    0 	8.12
;i8  4.5625      0.05    0 	8.13
i8  4.625       0.05    0 	8.10
i8  4.6875      0.05    0 	8.12
;i8  4.75        0.05    0 	8.13
i8  4.8125      0.05    0 	8.15
;i8  4.875       0.05    0 	8.13
i8  4.9375      0.05    0 	8.12

i8  5           0.02    0 	8.13
i8  5.0625      0.02    0 	8.12
i8  5.125       0.02    0 	8.10
i8  5.1875      0.02    0 	8.13
i8  5.25        0.02    0 	8.12
i8  5.3125      0.02    0 	8.10
i8  5.375       0.02    0 	8.08
i8  5.4375      0.02    0 	8.06
i8  5.5         0.02    0 	8.12
i8  5.5625      0.02    0 	8.13
i8  5.625       0.02    0 	8.10
i8  5.6875      0.02    0 	8.12
i8  5.75        0.02    0 	8.13
i8  5.8125      0.02    0 	8.15
i8  5.875       0.02    0 	8.13
i8  5.9375      0.02    0 	8.1

i8  6           0.05    0 	8.10
i8  6.0625      0.05    0 	8.08
i8  6.125       0.05    0 	8.06
i8  6.1875      0.05    0 	8.03
i8  6.25        0.05    0 	8.01
i8  6.3125      0.05    0 	8.10
i8  6.375       0.05    0 	8.08
i8  6.4375      0.05    0 	8.06
i8  6.5         0.05    0 	8.12
i8  6.5625      0.05    0 	8.13
i8  6.625       0.05    0 	8.10
i8  6.6875      0.05    0 	8.12
i8  6.75        0.05    0 	8.13
i8  6.8125      0.05    0 	8.15
i8  6.875       0.05    0 	8.13
i8  6.9375      0.05    0 	8.12

i8  7           0.02    0 	8.13
i8  7.0625      0.02    0 	8.12
i8  7.125       0.02    0 	8.10
i8  7.1875      0.02    0 	8.13
i8  7.25        0.02    0 	8.12
i8  7.3125      0.02    0 	8.10
i8  7.375       0.02    0 	8.08
i8  7.4375      0.02    0 	8.06
i8  7.5         0.02    0 	8.12
i8  7.5625      0.02    0 	8.13
i8  7.625       0.02    0 	8.10
i8  7.6875      0.02    0 	8.12
i8  7.75        0.02    0 	8.13
i8  7.8125      0.02    0 	8.15
i8  7.875       0.02    0 	8.13
i8  7.9375      0.02    0 	8.12






<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>100</x>
 <y>100</y>
 <width>320</width>
 <height>240</height>
 <visible>true</visible>
 <uuid/>
 <bgcolor mode="nobackground">
  <r>255</r>
  <g>255</g>
  <b>255</b>
 </bgcolor>
</bsbPanel>
<bsbPresets>
</bsbPresets>
