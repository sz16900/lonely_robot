<Cabbage>
form caption("CsoundMelody2"),
hslider channel("heightSlider"), text("Height"), range(-16, -7, -7)
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


gkPitch0 = 0
gkPitch1 = 1
gkPitch2 = 2
instr PLAYER_MOVE

	kHeight chnget "heightSlider"
 printks "gkPitch (%d)  kheight: %d\n", 0.25, gkPitch0, kHeight
      if kHeight >-14 && kHeight<=-12 then		;3 possible outcomes
         gkPitch0 = 1			
      elseif kHeight >-12 && kHeight<=-10 then
	    gkPitch0 = 5
      elseif kHeight >-10 && kHeight<=-8 then
	    gkPitch0 = 7
      elseif kHeight >-8 && kHeight<=-6 then
	    gkPitch0 = 9	    
      elseif kHeight > -6 then
	    gkPitch0 = 12	    
	endif
      printks "gkPitch (%d) \n", 0.25, gkPitch0
endin

instr 1 				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     0.25 , p3, 0         ; amplitude envelope
	a1 	oscil 	aEnv, cpspch(p5), 1 	; audio oscillator
	out 	a1, a1 		; send signal to channel 1
endin

instr 2 				
	;kctrl 	line 	0, p3, 1 	; amplitude envelope
      aEnv     line     0.1, p3, 0.1         ; amplitude envelope
	asig 	oscil 	aEnv, cpspch(p5 + (gkPitch0)/100), 2 	; audio oscillator
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
aenv expon 0.90, p3, 0.01
a1  poscil    1, k1, 3
outs a1*aenv, a1*aenv
endin 








</CsInstruments>
<CsScore>


f1 	0 	256 	10 	1 	;  a sine wave function table

f2 0 1024 5 0.1 20 1 100 0.001 	;  a sine wave function table

f3 0 1024 10 1 

;i"PLAYER_MOVE" 0 [3600*12]
r 8 CNT

i"PLAYER_MOVE" 0 8

;kicks
i3 0         0.5  100 
i3 0.75      0.5  100 
i3 2.75      0.5  100 
i3 3.00      0.5  100 
i3 4         0.5  100 
i3 4.75      0.5  100 
i3 6.00      0.5  100 
i3 6.75      0.5  100 
i3 7.25      0.5  100
i3 7.50      0.5  100
i3 7.75      0.25 100







i2  [0.00 + 0.0 * $CNT.]  1    0 	6.06 
i2  [4.00 + 0.0 * $CNT.]  1    0 	6.03
i2  [6.00 + 0.0 * $CNT.]  1    0 	6.01

i2  [0.00 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
i2  [0.25 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
i2  [0.50 + 0.0 * $CNT.]  .25    0 	   [7.06 - 0]
i2  [0.75 + 0.0 * $CNT.]  .25    0        [7.06 - 0]

 
i1  [4.00 + 0.0 * $CNT.]  1.25    0 	7.03
i1  [6.00 + 0.0 * $CNT.]  1.25    0 	7.01



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




i2  [0.00 + 0.0 * $CNT.]  .25    0 	8.10  
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
