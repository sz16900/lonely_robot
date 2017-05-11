<CsoundSynthesizer>
<CsOptions>
</CsOptions>
<CsInstruments>
sr = 44100
ksmps = 4

nchnls = 2
0dbfs = 1
giSine ftgen 0, 0, 4096, 10, 1; a sine wave with a plucked envelope:





instr 1
idur = p3 
iamp = p4 
ifrq cps2pch p5, 12 
kamp line iamp, idur, 0
asig oscili kamp, ifrq, giSine


outs asig, asig
endin
</CsInstruments>
<CsScore>


r 4 0 

i1 0 1 0.25 9.00
i1 +
i1 + . . 9.04
i1 +
i1 + . . 9.07
i1 +
i1 + 2 . 9.04s
s
e



</CsScore>
</CsoundSynthesizer>







f 1 0 16384 10 1

; We'll repeat this section 6 times. Each time it 
; is repeated, its macro REPS_MACRO is incremented. 
r 6 REPS_MACRO

; Play Instrument #1.
; p4 = the r statement's macro, REPS_MACRO.
; p5 = the frequency in cycles per second.
i1 00.10 00.10 $REPS_MACRO 1760
i1 00.30 00.10 $REPS_MACRO 880
i1 00.50 00.10 $REPS_MACRO 440
i1 00.70 00.10 $REPS_MACRO 220

; Marks the end of the section.
s

e










r6

i1 0   1   0.25   9.00
i1 + 
i1 +   .    .     9.04 
i1 + 
i1 +   .    .     9.07 
i1 + 
i1 +   2    .     9.04
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
