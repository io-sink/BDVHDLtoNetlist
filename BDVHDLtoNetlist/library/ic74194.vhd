library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74194 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74194 is "74xx";
	attribute component_name of ic74194 is "74HC194";
	attribute footprint_name of ic74194 is "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 8;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 16;
	attribute pin_type of VCC is "power_in";

  CLK : in std_logic;
	attribute pin_assign of CLK is 11;
	attribute pin_type of CLK is "input";
  CLRN : in std_logic;
	attribute pin_assign of CLRN is 1;
	attribute pin_type of CLRN is "input";

  SLSI : in std_logic;
	attribute pin_assign of SLSI is 7;
	attribute pin_type of SLSI is "input";
  SRSI : in std_logic;
	attribute pin_assign of SRSI is 2;
	attribute pin_type of SRSI is "input";

  A : in std_logic;
	attribute pin_assign of A is 3;
	attribute pin_type of A is "input";
  B : in std_logic;
	attribute pin_assign of B is 4;
	attribute pin_type of B is "input";
  C : in std_logic;
	attribute pin_assign of C is 5;
	attribute pin_type of C is "input";
  D : in std_logic;
	attribute pin_assign of D is 6;
	attribute pin_type of D is "input";

  S0 : in std_logic;
	attribute pin_assign of S0 is 9;
	attribute pin_type of S0 is "input";
  S1 : in std_logic;
	attribute pin_assign of S1 is 10;
	attribute pin_type of S1 is "input";

  QA : out std_logic;
  attribute pin_assign of QA is 15;
  attribute pin_type of QA is "output";
  QB : out std_logic;
  attribute pin_assign of QB is 14;
  attribute pin_type of QB is "output";
  QC : out std_logic;
  attribute pin_assign of QC is 13;
  attribute pin_type of QC is "output";
  QD : out std_logic;
  attribute pin_assign of QD is 12;
  attribute pin_type of QD is "output"
	);
	end ic74194;

architecture logic of ic74194 is 

  component comp74194
    port (
      CLK :  IN  STD_LOGIC;
      CLRN :  IN  STD_LOGIC;
      SLSI :  IN  STD_LOGIC;
      SRSI :  IN  STD_LOGIC;
      A :  IN  STD_LOGIC;
      B :  IN  STD_LOGIC;
      C :  IN  STD_LOGIC;
      D :  IN  STD_LOGIC;
      S0 :  IN  STD_LOGIC;
      S1 :  IN  STD_LOGIC;
      QA :  OUT  STD_LOGIC;
      QB :  OUT  STD_LOGIC;
      QC :  OUT  STD_LOGIC;
      QD :  OUT  STD_LOGIC
    );
  end component;

begin 

  inst : comp74194
    port map (
      CLK => CLK, 
      CLRN => CLRN, 
      SLSI => SLSI, 
      SRSI => SRSI, 
      A => A, 
      B => B, 
      C => C, 
      D => D, 
      S0 => S0, 
      S1 => S1, 
      QA => QA, 
      QB => QB, 
      QC => QC, 
      QD => QD
    );

end logic;