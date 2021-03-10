library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74151 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74151 is "74xx";
	attribute component_name of ic74151 is "74HC151";
	attribute footprint_name of ic74151 is "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 8;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 16;
	attribute pin_type of VCC is "power_in";

  STN : in std_logic;
	attribute pin_assign of STN is 7;
	attribute pin_type of STN is "input";

	A : in std_logic;
	attribute pin_assign of A is 11;
	attribute pin_type of A is "input";
	B : in std_logic;
	attribute pin_assign of B is 10;
	attribute pin_type of B is "input";
	C : in std_logic;
	attribute pin_assign of C is 9;
	attribute pin_type of C is "input";

	D0 : in std_logic;
	attribute pin_assign of D0 is 4;
	attribute pin_type of D0 is "input";
	D1 : in std_logic;
	attribute pin_assign of D1 is 3;
	attribute pin_type of D1 is "input";
	D2 : in std_logic;
	attribute pin_assign of D2 is 2;
	attribute pin_type of D2 is "input";
	D3 : in std_logic;
	attribute pin_assign of D3 is 1;
	attribute pin_type of D3 is "input";
	D4 : in std_logic;
	attribute pin_assign of D4 is 15;
	attribute pin_type of D4 is "input";
	D5 : in std_logic;
	attribute pin_assign of D5 is 14;
	attribute pin_type of D5 is "input";
	D6 : in std_logic;
	attribute pin_assign of D6 is 13;
	attribute pin_type of D6 is "input";
	D7 : in std_logic;
	attribute pin_assign of D7 is 12;
	attribute pin_type of D7 is "input";

	Y : out std_logic;
	attribute pin_assign of Y is 5;
	attribute pin_type of Y is "output";
	W : out std_logic;
	attribute pin_assign of W is 6;
	attribute pin_type of W is "output"
	);
	end ic74151;

architecture logic of ic74151 is 
  component comp74151
    port (
      STN :  IN  STD_LOGIC;
      D0 :  IN  STD_LOGIC;
      D1 :  IN  STD_LOGIC;
      D2 :  IN  STD_LOGIC;
      D3 :  IN  STD_LOGIC;
      D4 :  IN  STD_LOGIC;
      D5 :  IN  STD_LOGIC;
      D6 :  IN  STD_LOGIC;
      D7 :  IN  STD_LOGIC;
      A :  IN  STD_LOGIC;
      B :  IN  STD_LOGIC;
      C :  IN  STD_LOGIC;
      W :  OUT  STD_LOGIC;
      Y :  OUT  STD_LOGIC
    );
  end component;

begin 

  inst : comp74151
    port map (
      STN => STN, 
      D0 => D0, 
      D1 => D1, 
      D2 => D2, 
      D3 => D3, 
      D4 => D4, 
      D5 => D5, 
      D6 => D6, 
      D7 => D7, 
      A => A, 
      B => B, 
      C => C, 
      W => W, 
      Y => Y
    );

end logic;