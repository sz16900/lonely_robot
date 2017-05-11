<Cabbage>
form caption("CsoundMelody2"),
hslider channel("relativeHeightSlider"), text("Relative Height"), range(0, 9, 0)
;hslider channe2("absoluteHeightSlider"), text("Absolute Hight"),
;range(0, 9, 0)
hslider channe3("wheelSlider"), text("Wheel Proximity"),
range(0, 1, 0)
hslider channe3("AfterDemoSlider"), text("After Demo"),
range(0, 1, 0)
hslider channe3("PlatformSlider"), text("Platform Proximity"),
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

giEvl0 init 0.00
gkEnv init 0 
gkWheel init 0 
gkNotWheel init 0.1
gkPitch0 = 0.0
gkPitch2 = 2
gkKickVol = 0



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
instr PLAYER_MOVE

	kHeight  chnget "relativeHeightSlider"
 ;printks "gkPitch (%d)  kheight: %d\n", 0.25, gkPitch0, kHeight
      if kHeight<=0.5 then		;-15 
         gkPitch0 = 0			
      elseif  kHeight >0.5 && kHeight<=1 then		;-13 
         gkPitch0 = 12			
      elseif kHeight >1 && kHeight<=1.5 then    ;-11
	    gkPitch0 = 24
      elseif kHeight >1.5 then    ;-9
	    gkPitch0 = 36
 	endif
      ;printks "gkPitch (%d) \n", 0.25, gkPitch0
      

      iAbsHeight chnget "absoluteHeightSlider"
     if iAbsHeight>-11 then		;-15
         gkEnv = 1
     elseif  iAbsHeight <-11  then
          gkEnv = 0
     endif   
     
     iNearWheel chnget "wheelSlider"
     if iNearWheel= 0 then		;-15 
         gkWheel = 0	
         gkNotWheel = 0.1		
      elseif  iNearWheel >0 then     
         gkWheel = 0.1	
         gkNotWheel = 0
 	endif 
 	iAfterDemo chnget "AfterDemoSlider"
 	if iAfterDemo= 0 then		;-15 
         gkKickVol	= 0	
      elseif  iAfterDemo >0 then     
         gkKickVol = 0.60
 	endif 
 	iPlatform chnget "PlatformSlider"
 	if iPlatform= 0 then		;-15 
         gkPlatform	= 0	
      elseif  iPlatform >0 then     
         gkPlatform = 0.09
 	endif  	
 	
 	
 	      
printks "gkEnv0 (%f) \n, abs height (%d)", 0.25, gkEnv,iAbsHeight
endin

instr 1 				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     i(gkWheel) , p3, 0;i(gkWheel)        ; amplitude envelope
	a1 	oscil 	aEnv, cpspch(p5 + ((gkPitch0)/100)  ), 4 	; audio oscillator
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
      aEnv     line     0.1, p3, 0;i(gkEnv);giEvl0
      ;aEnv adsr p3*.3, p3*.1, .4, p3*.1 ;         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5  ), 5 	; audio oscillator
	out 	asig, asig 		; send signal to channel 1

endin


instr 7 ;platform				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     i(gkPlatform), p3, 0;i(gkPlatform);i(gkPlatform);giEvl0
      ;aEnv adsr p3*.3, p3*.1, .4, p3*.1 ;         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5  ), 5 	; audio oscillator
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
aenv expon i(gkKickVol), p3, 0.01
a1  poscil    1, k1, 3
outs a1*aenv, a1*aenv
endin 








</CsInstruments>
<CsScore>
f1 0 65536 10 1

f1 	0 	256 	10 	1 	;  a sine wave function table

f2 0 1024 5 0.1 20 1 100 0.001 	;  a sine wave function table


;f3 0 1024 5 0.1 20 1 100 0.001 
f4 0 1024 5 0.1 20 1 100 0.001
f5 0 1024 5 0.1 20 1 100 0.001
f3 0 1024 10 1 

;i"PLAYER_MOVE" 0 [3600*12]
r 50 CNT


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

i5  [0.00 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
i5  [0.25 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
i5  [0.50 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
i5  [0.75 + 0.0 * $CNT.]  .25    0        [7.06 - 0]

 
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
