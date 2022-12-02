<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                >
    <xsl:output method="xml" indent="yes"/>
    <xsl:include href="../CommonXsltTemplates.xslt"/>
    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>Day02.xml</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve"><AdventOfCode>
    <Year2022>
        <Day02>
            <Signs>
                <xsl:for-each select="//Signs/Sign"><xsl:sort select="WinScore"/>
                    <xsl:apply-templates select="." />
                </xsl:for-each>
            </Signs>
            <SampleGames>
                <xsl:for-each select="//SampleGames/SampleGame">
                    <xsl:apply-templates select="." />
                </xsl:for-each>
            </SampleGames>
        </Day02>
    </Year2022>
                    </AdventOfCode>
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
    <xsl:template match="Image">
        <Image><xsl:value-of select="url"/></Image>
    </xsl:template>
    <xsl:template match="WinsAgainstImage">
        <WinsAgainstImage>
            <xsl:value-of select="url"/>
        </WinsAgainstImage>
    
</xsl:template>
    <xsl:template match="LosesToImage">
        <LosesToImage>
            <xsl:value-of select="url"/>
        </LosesToImage>
    </xsl:template>
    <xsl:template match="Sign">
        <Sign>
            <xsl:apply-templates select="Name" />
            <xsl:apply-templates select="OpponentCode" />
            <xsl:apply-templates select="SuggestionCode" />
            <xsl:apply-templates select="SuggestionCodeToWin" />
            <xsl:apply-templates select="SuggestionCodeToLose" />
            <xsl:apply-templates select="ValueWhenThrown" />
            <xsl:apply-templates select="LossScore" />
            <xsl:apply-templates select="DrawScore" />
            <xsl:apply-templates select="WinScore" />
            <xsl:apply-templates select="WinsAgainstName" />
            <xsl:apply-templates select="LosesToName" />
            <xsl:apply-templates select="Image" />
            <xsl:apply-templates select="WinsAgainstImage" />
            <xsl:apply-templates select="LosesToImage" />
        </Sign>
    </xsl:template>
    <xsl:template match="SampleGame">
        <SampleGame>
            <xsl:apply-templates select="Name" />
            <xsl:apply-templates select="GameScore" />
            <xsl:apply-templates select="SampleRoundNames" />
            <xsl:for-each select="//SampleRounds/SampleRound">
                <xsl:sort select="Name"/>
                <xsl:apply-templates select="." />
            </xsl:for-each>
        </SampleGame>
    </xsl:template>
    <xsl:template match="SampleRound">
        <SampleRound>
            <xsl:apply-templates select="Name" />
            <xsl:apply-templates select="OpponentPlays" />
            <xsl:apply-templates select="OppenentCode" />
            <xsl:apply-templates select="SuggestionName" />
            <xsl:apply-templates select="SuggestionCode" />
            <xsl:apply-templates select="RoundStatus" />
            <xsl:apply-templates select="Score" />
            <xsl:apply-templates select="SuggestionThrowValue" />
            <xsl:apply-templates select="Notes" />
            <xsl:apply-templates select="OppenentWinsAgainst" />
            <xsl:apply-templates select="OppenentLosesTo" />
        </SampleRound>
    </xsl:template>

</xsl:stylesheet>
