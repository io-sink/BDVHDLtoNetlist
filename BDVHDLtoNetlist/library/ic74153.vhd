library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74153 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74153 is "74xx";
	attribute component_name of ic74153 is "74HC153";
	attribute footprint_name of ic74153 is "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 8;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 16;
	attribute pin_type of VCC is "power_in";

  A : in std_logic;
  attribute pin_assign of A is 14;
  attribute pin_type of A is "input";
  B : in std_logic;
  attribute pin_assign of B is 2;
  attribute pin_type of B is "input";

  C10 : in std_logic;
  attribute pin_assign of C10 is 6;
  attribute pin_type of C10 is "input";
  C11 : in std_logic;
  attribute pin_assign of C11 is 5;
  attribute pin_type of C11 is "input";
  C12 : in std_logic;
  attribute pin_assign of C12 is 4;
  attribute pin_type of C12 is "input";
  C13 : in std_logic;
  attribute pin_assign of C13 is 3;
  attribute pin_type of C13 is "input";

  C20 : in std_logic;
  attribute pin_assign of C20 is 10;
  attribute pin_type of C20 is "input";
  C21 : in std_logic;
  attribute pin_assign of C21 is 11;
  attribute pin_type of C21 is "input";
  C22 : in std_logic;
  attribute pin_assign of C22 is 12;
  attribute pin_type of C22 is "input";
  C23 : in std_logic;
  attribute pin_assign of C23 is 13;
  attribute pin_type of C23 is "input";

  GN1 : in std_logic;
  attribute pin_assign of GN1 is 1;
  attribute pin_type of GN1 is "input";
  GN2 : in std_logic;
  attribute pin_assign of GN2 is 15;
  attribute pin_type of GN2 is "input";

  Y1 : out std_logic;
  attribute pin_assign of Y1 is 7;
  attribute pin_type of Y1 is "output";
  Y2 : out std_logic;
  attribute pin_assign of Y2 is 9;
  attribute pin_type of Y2 is "output"
	);
	end ic74153;

architecture logic of ic74153 is 
  component comp74153
    port (
      A :  IN  STD_LOGIC;
      B :  IN  STD_LOGIC;
      C10 :  IN  STD_LOGIC;
      C11 :  IN  STD_LOGIC;
      C12 :  IN  STD_LOGIC;
      C13 :  IN  STD_LOGIC;
      C20 :  IN  STD_LOGIC;
      C21 :  IN  STD_LOGIC;
      C22 :  IN  STD_LOGIC;
      C23 :  IN  STD_LOGIC;
      GN1 :  IN  STD_LOGIC;
      GN2 :  IN  STD_LOGIC;
      Y1 :  OUT  STD_LOGIC;
      Y2 :  OUT  STD_LOGIC
    );
  end component;
begin 

  inst : comp74153
    port map (
      A => A,
      B => B,
      C10 => C10,
      C11 => C11,
      C12 => C12,
      C13 => C13,
      C20 => C20,
      C21 => C21,
      C22 => C22,
      C23 => C23,
      GN1 => GN1,
      GN2 => GN2,
      Y1 => Y1,
      Y2 => Y2
    );

end logic;